using Comun;
using Microsoft.AspNetCore.SignalR.Client;
using Modelo;
using Modelo.OtherModels;
using Modelo.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VectorCliente.Services.IServices;

namespace VectorCliente.Services
{
    public class ServiceEscalafon
    {
        private readonly IServiceDataEscalafon serviceDataEscalafon;
        private readonly IServiceFuncionario serviceFuncionario;
        private readonly HubConnection hubConnection;
        public ServiceEscalafon(IServiceDataEscalafon _serviceDataEscalafon, IServiceFuncionario _serviceFuncionario, HubConnection _hubConnection)
        {
            serviceDataEscalafon = _serviceDataEscalafon;
            serviceFuncionario = _serviceFuncionario;
            hubConnection = _hubConnection;
        }
        public EscalafonModel EscalafonModel { get; set; }

        #region "Estructuras principales"
        public List<EscalafonServiciosData> EscalafonServicioData { get; set; } //Para estados fijos
        public List<EscalafonServiciosData> EscalafonServiciosFiltro { get; set; }
        public List<PlanificacionDiariaDTO> BolsaEstados { get; set; } //Para estados rotatorios
        public Dictionary<string,int> FuncionariosSE { get; set; }
        #endregion
        public GanttModel GantModelFiltro { get; set; }
        public DateTime FechaPlanificacion { get; set; }
        public int IdMesaOperativaEnPlanificacion { get; set; }
        public UsuarioDTO UsuarioDTO { get; set; }
        public FiltroEscalafon filtroEscalafon { get; set; }

        public async Task Inicializar(GeneralTransport modelo, UsuarioDTO usuarioDTO, bool copia)
        {
            FechaPlanificacion = copia ? modelo.FechaFin : modelo.Fecha;
            UsuarioDTO = usuarioDTO;
            filtroEscalafon = new()
            {
                FiltroIdCliente = 0,
                FiltroNombreServicio = string.Empty
            };
        }

        public async Task CrearNuevo(GeneralTransport modelo)
        {
            try {
                EscalafonModel = await serviceDataEscalafon.CrearNuevo(modelo, UsuarioDTO.Token);
                EscalafonModel.ServiciosDTO = EscalafonModel.ServiciosDTO.OrderByDescending(o => o.Id).ToList();
                await ActualizarEstructuraDeServicios();
                await FiltrarEscalafon();
                await CargarBolsa();
                await hubConnection.StartAsync();
            } catch (Exception ex)
            {
                new Exception(ex.Message);
            }
        }
        private async Task CargarBolsa()
        {
            BolsaEstados = new List<PlanificacionDiariaDTO>();
            if (EscalafonModel.planesDiarios != null && EscalafonModel.planesDiarios.Count > 0) 
            {
                BolsaEstados = EscalafonModel.planesDiarios.Where(w => w.Rotativo == true).ToList();
            }
        }
       
        private async Task CargarFuncionariosSE()
        {
            FuncionariosSE = new Dictionary<string, int>();
            foreach (var funcionario in EscalafonModel.funcionariosDTO)
            {
                FuncionariosSE.Add(funcionario.NumeroNombres(),0);
            }

            foreach (var estado in EscalafonModel.planesDiarios)
            {
                FuncionariosSE[estado.FuncionarioOperativo.NumeroNombres()] = FuncionariosSE[estado.FuncionarioOperativo.NumeroNombres()] + 1;
            }
        }

        private async Task ActualizarFuncionarioSE(int conteo, FuncionarioDTO funcionarioDTO)
        {
                FuncionariosSE[funcionarioDTO.NumeroNombres()] = FuncionariosSE[funcionarioDTO.NumeroNombres()] + conteo;
        }
        public async Task AbrirEscalafon(GeneralTransport modelo)
        {
            try
            {
                EscalafonModel = await serviceDataEscalafon.AbrirPlanificacion(modelo, UsuarioDTO.Token);
                EscalafonModel.ServiciosDTO = EscalafonModel.ServiciosDTO.OrderByDescending(o => o.Id).ToList();
                await ActualizarEstructuraDeServicios();
                filtroEscalafon.FiltroIdCliente = EscalafonModel.ServiciosDTO[0].Cliente.Id;
                await FiltrarEscalafon();
                await CargarBolsa();

                await hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }
        }
        public async Task CopiaEscalafon(GeneralTransport modelo)
        {
            try
            {
                EscalafonModel = await serviceDataEscalafon.CopiaEscalafon(modelo, UsuarioDTO.Token);
                EscalafonModel.ServiciosDTO = EscalafonModel.ServiciosDTO.OrderByDescending(o => o.Id).ToList();
                await ActualizarEstructuraDeServicios();
                await FiltrarEscalafon();
                await CargarBolsa();
                await CargarFuncionariosSE();

                await hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }
        }

        public async Task ActualizarEstructuraDeServicios()
        {
            EscalafonServicioData = new();
            List<EscalafonServiciosData> auxData = new();

            if (EscalafonModel.planesDiarios != null)
            {
                    foreach(ServicioDTO serv in EscalafonModel.ServiciosDTO)
                {
                    auxData.Add(new EscalafonServiciosData()
                    {
                        ServicioDTO = serv,
                        EstadosDTO = EscalafonModel.planesDiarios.Where(w => w.Servicio.Id == serv.Id && 
                                                                             w.MostrarEnEscalafon == true).ToList()
                });
                }
                EscalafonServicioData.AddRange(auxData);
            }
            else
            {
                foreach (ServicioDTO serv in EscalafonModel.ServiciosDTO)
                {
                    auxData.Add(new EscalafonServiciosData()
                    {
                        ServicioDTO = serv,
                        EstadosDTO= new()
                    });
                }
                EscalafonServicioData.AddRange(auxData);
            }
        }
       
        public async Task FiltrarEscalafon()
        {
            EscalafonServiciosFiltro = null;

            if (filtroEscalafon.FiltroIdCliente > 0)
            {
                EscalafonServiciosFiltro = EscalafonServicioData.Where(w => w.ServicioDTO.Cliente.Id == filtroEscalafon.FiltroIdCliente).ToList();

            }
            else if (!string.IsNullOrEmpty(filtroEscalafon.FiltroNombreServicio))
            {
                EscalafonServiciosFiltro = EscalafonServicioData.Where(w => w.ServicioDTO.NombreDescriptivo.ToUpper().Contains(filtroEscalafon.FiltroNombreServicio.ToUpper())).ToList();
              
            }
            else
            {
                EscalafonServiciosFiltro = EscalafonServicioData;
            }
        }

        public async Task<FuncionarioDTO> ObtenerFuncionarioSegunNumero(string data)
        {
            try {
                if (string.IsNullOrEmpty(data) || data.Length <5)
                    throw new Exception("El funcionario de segundo nivel no se puede encontrar o no existe. Verifique");

                string[] separador = data.Split("-");
                if (separador.Length != 2)
                    throw new Exception("El funcionario de segundo nivel no se puede encontrar o no existe");

                int numeroFuncionario = SD.ConvertStringToInt(separador[0]);

                if (numeroFuncionario == -1)
                    throw new Exception("No se encontró al funcionario de segunfo nivel");

                return await serviceFuncionario.ObtenerFuncionarioSegunNumero(numeroFuncionario, UsuarioDTO.Token);

            }
            catch (Exception ex){
                throw new Exception(ex.Message);
            }

        }//ok
        public Task<bool> ExisteFechaEscalafon(GeneralTransport modelo)
        {
            return serviceDataEscalafon.ExisteFechaEscalafon(modelo, UsuarioDTO.Token);
        }

        public async Task<List<FuncionarioDTO>> BusquedaFuncionario(GeneralTransport busqueda)
        {
            try
            {
                List<FuncionarioDTO> funcionarios;
                funcionarios = await serviceFuncionario.BusquedaFuncionariosEnMesa(busqueda,UsuarioDTO.Token);
                return funcionarios;
            }
            catch (Exception e)
            {
                return null;
            } 
        } //ok

        public async Task<PlanificacionDiariaDTO> AgregarEstado(PlanificacionDiariaDTO plan)
        {
            try
            {
                if (string.IsNullOrEmpty(plan.FuncionarioOperativo.Celular))
            {
                throw new Exception("No puede dejar vacio el celular de contacto. Si aun no tiene el celular de contacto ponga un 0 (cero)");
            }
            if (plan.SegundoNivel) { 
                var estadosEnServicio = EscalafonServiciosFiltro.SingleOrDefault(c => c.ServicioDTO.Id == plan.Servicio.Id);
                int cantidadEstadosEnServicio = estadosEnServicio.EstadosDTO.Count(e => e.Orden == plan.Orden);
                    if (cantidadEstadosEnServicio > 1)
                        throw new Exception("Ya asignó un estado de segundo nivel con el funcionario seleccionado");
                }

                PlanificacionDiariaDTO planNuevo = await serviceDataEscalafon.AgregarNuevoPlanDiario(plan, UsuarioDTO.Token);
                await hubConnection.SendAsync("SendEstadoHub", planNuevo);
                //await hubConnection.SendAsync("SendEstadoBolsaHub", planNuevo);
                return planNuevo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//ok

        public async Task<PlanificacionDiariaDTO> ActualizarPlanDiario(PlanificacionDiariaDTO plan)
        {
            try
            {
                PlanificacionDiariaDTO planActualizado = await serviceDataEscalafon.ActualizarPlanDiario(plan, UsuarioDTO.Token);
                if (planActualizado == null) throw new Exception("No se ha podido actualizar. Err 205");
                //await ActualizarEstadoFrontEnd(planActualizado);
                await hubConnection.SendAsync("SendEstadoHub", planActualizado);
                //await hubConnection.SendAsync("SendEstadoBolsaHub", planActualizado);
                return planActualizado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//ok

        public async Task<PlanificacionDiariaDTO> MoverAOtroServicioPlanDiario(PlanificacionDiariaDTO plan, ServicioDTO servicioAnterior)
        {
            try
            {
                PlanificacionDiariaDTO planActualizado = await serviceDataEscalafon.ActualizarPlanDiario(plan, UsuarioDTO.Token);
                if (planActualizado == null) throw new Exception("No se ha podido actualizar. Err 205");
                
                await hubConnection.SendAsync("SendMoverDeServicioHub", planActualizado, servicioAnterior);
                return planActualizado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task MoverAOtroServicioPlanDiarioFrontEnd(PlanificacionDiariaDTO plan,ServicioDTO servicioAnterior)
        {
            var servicioFiltrado = EscalafonServicioData.SingleOrDefault(w => w.ServicioDTO.Id == servicioAnterior.Id);
            servicioFiltrado.EstadosDTO.RemoveAll(r => r.Id == plan.Id);
        }


        public async Task<bool> EliminarPlanDiario(PlanificacionDiariaDTO plan)
        {
            try
            {
                PlanificacionDiariaDTO estadoAEliminar = await serviceDataEscalafon.EliminarEstado(plan, UsuarioDTO.Token);

                await hubConnection.SendAsync("SendEstadoHub", estadoAEliminar);
                //await hubConnection.SendAsync("SendEstadoBolsaHub", estadoAEliminar);
                return true;
            }
                catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }

        public async Task ABMBolsaFrontEnd(PlanificacionDiariaDTO estado)
        {
            //AgregarActualizarEliminar actualizar en bolsa
            if (estado.IdMesaOperativa == IdMesaOperativaEnPlanificacion &&
            estado.ModalidadActualizacionBolsa == SD.ModalidadActualizacion.AGREGAR.ToString() &&
            estado.Fecha.Date == FechaPlanificacion.Date)
            {
                BolsaEstados.Add(estado);
            }
            if (estado.IdMesaOperativa == IdMesaOperativaEnPlanificacion &&
                estado.ModalidadActualizacionBolsa == SD.ModalidadActualizacion.ACTUALIZAR.ToString() &&
                estado.Fecha.Date == FechaPlanificacion.Date)
            {
                BolsaEstados.RemoveAll(r => r.Id == estado.Id);
                BolsaEstados.Add(estado);
            }

            if (estado.IdMesaOperativa == IdMesaOperativaEnPlanificacion &&
               estado.ModalidadActualizacionBolsa == SD.ModalidadActualizacion.ELIMINAR.ToString() &&
               estado.Fecha.Date == FechaPlanificacion.Date)
            {
                BolsaEstados.RemoveAll(r => r.Id == estado.Id);
            }

        }

        public async Task ABMEscalafonBolsaFrontEnd(PlanificacionDiariaDTO estado)
        {
            //agregar actualizarEliminar en escalafon
            if (estado.IdMesaOperativa == IdMesaOperativaEnPlanificacion &&
               estado.ModalidadActualizacionEscalafon == SD.ModalidadActualizacion.AGREGAR.ToString() &&
               estado.Fecha.Date == FechaPlanificacion)
            {
                var busquedaEnEscalafon = EscalafonServicioData.SingleOrDefault(w => w.ServicioDTO.Id == estado.Servicio.Id);
                busquedaEnEscalafon.EstadosDTO.Add(estado);
            }

            if (estado.IdMesaOperativa == IdMesaOperativaEnPlanificacion &&
              estado.ModalidadActualizacionEscalafon == SD.ModalidadActualizacion.ACTUALIZAR.ToString() &&
              estado.Fecha.Date == FechaPlanificacion)
            {
                var busquedaEnEscalafon = EscalafonServicioData.SingleOrDefault(w => w.ServicioDTO.Id == estado.Servicio.Id);
                busquedaEnEscalafon.EstadosDTO.RemoveAll(r => r.Id == estado.Id);
                busquedaEnEscalafon.EstadosDTO.Add(estado);
            }

            if (estado.IdMesaOperativa == IdMesaOperativaEnPlanificacion &&
              estado.ModalidadActualizacionEscalafon == SD.ModalidadActualizacion.ELIMINAR.ToString() &&
              estado.Fecha.Date == FechaPlanificacion)
            {
                var busquedaEnEscalafon = EscalafonServicioData.SingleOrDefault(w => w.ServicioDTO.Id == estado.Servicio.Id);
                busquedaEnEscalafon.EstadosDTO.RemoveAll(r => r.Id == estado.Id);
            }

            //rotativos

            if (estado.IdMesaOperativa == IdMesaOperativaEnPlanificacion &&
            estado.ModalidadActualizacionBolsa == SD.ModalidadActualizacion.AGREGAR.ToString() &&
            estado.Fecha.Date == FechaPlanificacion.Date)
            {
                BolsaEstados.Add(estado);
            }
            if (estado.IdMesaOperativa == IdMesaOperativaEnPlanificacion &&
                estado.ModalidadActualizacionBolsa == SD.ModalidadActualizacion.ACTUALIZAR.ToString() &&
                estado.Fecha.Date == FechaPlanificacion.Date)
            {
                BolsaEstados.RemoveAll(r => r.Id == estado.Id);
                BolsaEstados.Add(estado);
            }

            if (estado.IdMesaOperativa == IdMesaOperativaEnPlanificacion &&
               estado.ModalidadActualizacionBolsa == SD.ModalidadActualizacion.ELIMINAR.ToString() &&
               estado.Fecha.Date == FechaPlanificacion.Date)
            {
                BolsaEstados.RemoveAll(r => r.Id == estado.Id);
            }

        }

        public async Task<NombrePuestoDTO> AgregarNombrePuestoNuevo(NombrePuestoDTO nombrePuestoDTO)
        {
            try
            {
                NombrePuestoDTO np = await serviceDataEscalafon.AgregarNombrePuesto(nombrePuestoDTO, UsuarioDTO.Token);
                if (np != null)
                {
                    return np;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//ok
                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
        public async Task<List<NombrePuestoDTO>> ObtenerNombresPuestos(GeneralTransport modelo)
        {
            try
            {
                List<NombrePuestoDTO> nombresPuestos = await serviceDataEscalafon.ObtenerNombrePuestos(modelo, UsuarioDTO.Token);
                return nombresPuestos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                                                                                    
            }
        }//ok

        public async Task<List<GanttModel>> ObtenerAusenciasGantt(string filtro, bool fechaLmite,DateTime fechaPlanif, string token) //revisar
        {
            try
            {
                FiltroGantt filtroGantt = new()
                {
                 FechaLimite = fechaLmite,
                 Filtro = filtro,
                 FechaPlanificacion = fechaPlanif
                };

                List<GanttModel> dataGanttAusencias = await serviceDataEscalafon.ObtenerGanttAusencias(filtroGantt, token);
                return dataGanttAusencias;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PlanificacionDiariaDTO> AgregarFuncionarioPlanDiarioBolsa(FuncionarioFecha funcionarioFechaDTO) //se agrega desde la bolsa
        {
            try
            {
                funcionarioFechaDTO.Fecha = FechaPlanificacion;
                funcionarioFechaDTO.FuncionarioDto.Rotativo = true;
                PlanificacionDiariaDTO planNuevoBolsa = await serviceDataEscalafon.AgregarFuncionarioEnBolsa(funcionarioFechaDTO, UsuarioDTO.Token);
                
                await hubConnection.SendAsync("SendAgregarABolsaHub", planNuevoBolsa);
                return planNuevoBolsa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//**

        public async Task<bool> EliminarPlanDiarioBolsa(PlanificacionDiariaDTO plan) //revisar como actualizar la bolsa
        {
            try
            {//rever
                PlanificacionDiariaDTO resultado = await serviceDataEscalafon.EliminarEstado(plan, UsuarioDTO.Token);
                
                    EscalafonModel.planesDiarios.RemoveAll(r => r.Id == plan.Id); //borra del escalafon general
                    var funcionarioAModificar = EscalafonModel.funcionariosDTO.Single(f => f.Id == plan.FuncionarioOperativo.Id);
                    funcionarioAModificar.Rotativo = false;

                    await ActualizarEstructuraDeServicios();
                    await FiltrarEscalafon();
                    await CargarBolsa();
                    await ActualizarFuncionarioSE(-1, plan.FuncionarioOperativo);

                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//**

    }
}
