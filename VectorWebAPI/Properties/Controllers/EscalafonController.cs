using Comun;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Modelo.OtherModels;
using Modelo.ViewModels;
using Negocio.IRepositorios;
using Negocio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace VectorWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EscalafonController : Controller
    {
        private readonly RepoPlanificacionEscalafon repoEscalafon;
        private readonly IRepoServicio repoServicio;
        private readonly IRepoAusencia repoAusencia;
        private readonly IRepoCliente repoCliente;
        private readonly IRepoFuncionario repoFuncionario;

        public EscalafonController(RepoPlanificacionEscalafon _repoEscalafon, IRepoServicio _repoServicio, IRepoCliente _repoCliente,
                                    IRepoAusencia _repoAusencia, IRepoFuncionario _repoFuncionario)
        {
            repoEscalafon = _repoEscalafon;
            repoServicio = _repoServicio;
            repoAusencia = _repoAusencia;
            repoFuncionario = _repoFuncionario;
            repoCliente = _repoCliente;
        }


        [HttpPost("ExisteFechaEscalafon")]
        public async Task<IActionResult> ExisteEscalafonDiario([FromBody] GeneralTransport modelo)
        {
            bool existe = await repoEscalafon.ExisteFechaEscalafon(modelo);
            return Ok(existe);
        }
        [HttpPost("NuevoEscalafon")]
        public async Task<IActionResult> NuevoEscalafonDiario([FromBody] GeneralTransport modelo)
        {
            List<ServicioDTO> servicios = await repoServicio.ObtenerTodosActivosSegunMesaOperativa(modelo);
            List<ComputoDTO> computos = await repoEscalafon.ObtenerComputos();
            computos.RemoveAll(rem => rem.NombreDescriptivo == SD.ComputosEnum.BAJA.ToString());
            List<AusenciaDTO> ausencias = await repoAusencia.ObtenerEnFecha(modelo);

            Dictionary<string, ClienteDTO> clientesIteracion = new Dictionary<string, ClienteDTO>();
            List<ClienteDTO> clientes = new List<ClienteDTO>();
            foreach (var servicio in servicios)
            {
                if (!clientesIteracion.ContainsKey(servicio.Cliente.RazonSocial))
                    clientesIteracion.Add(servicio.Cliente.RazonSocial, servicio.Cliente);
            }

            //clientes = clientesIteracion.Select(s => s.Value).ToList();
            clientes = clientesIteracion.Values.ToList().OrderByDescending(d => d.Id).ToList();
            //clientes.OrderByDescending(d => d.Id);


            List<FuncionarioDTO> funcionariosOp = await repoFuncionario.ObtenerTodosActivosSegunMOP(modelo);

            FuncionarioDTO auxFun = new();
            List<PlanificacionDiariaDTO> auxPlan = new();

            foreach (var ausente in ausencias)
            {
                auxFun = funcionariosOp.SingleOrDefault(f => f.Id == ausente.Funcionario.Id);
                if (auxFun != null)
                {
                    auxPlan.Add(new PlanificacionDiariaDTO()
                    {
                        Fecha = modelo.Fecha.Date,
                        FuncionarioOperativo = ausente.Funcionario,
                        HoraEntrada = modelo.Fecha.Date,
                        HoraSalida = modelo.Fecha.Date,
                        Servicio = ausente.Servicio,
                        Computo = ausente.Computo,
                        Observaciones = ausente.Observaciones
                    });
                }
            }
            if (auxPlan != null && auxPlan.Count > 0) {
            auxPlan = await repoEscalafon.RegistrarLineasPlanificacion(auxPlan);
            }
            EscalafonModel escalafonModel = new()
            {
                ServiciosDTO = servicios,
                AusenciasDTO = ausencias,
                ClientesDTO = clientes,
                planesDiarios = auxPlan,
                ComputosDTO = computos,
                funcionariosDTO = funcionariosOp
            };

            return Ok(escalafonModel);
        }
        [HttpPost("AbrirEscalafon")]
        public async Task<IActionResult> AbrirEscalafonDiario([FromBody] GeneralTransport modelo)
        {
            bool existePlanificacion = await repoEscalafon.ExisteFechaEscalafon(modelo);
            if (!existePlanificacion)
            {
                return BadRequest(new ErrorModel("No existe la planificación de la fecha seleccionada", HttpStatusCode.BadRequest));
            }
            List<ServicioDTO> servicios = await repoServicio.ObtenerTodosActivosSegunMesaOperativa(modelo);
            List<ComputoDTO> computos = await repoEscalafon.ObtenerComputos();
            computos.RemoveAll(rem => rem.NombreDescriptivo == SD.ComputosEnum.BAJA.ToString());
            List<AusenciaDTO> ausencias = await repoAusencia.ObtenerEnFecha(modelo);

            Dictionary<string, ClienteDTO> clientesIteracion = new Dictionary<string, ClienteDTO>();
            List<ClienteDTO> clientes = new List<ClienteDTO>();
            foreach (var servicio in servicios)
            {
                if (!clientesIteracion.ContainsKey(servicio.Cliente.RazonSocial))
                    clientesIteracion.Add(servicio.Cliente.RazonSocial, servicio.Cliente);
            }

            //clientes = clientesIteracion.Select(s => s.Value).ToList();
            clientes = clientesIteracion.Values.ToList().OrderByDescending(d => d.Id).ToList();
            //clientes.OrderByDescending(d => d.Id);


            //List<FuncionarioDTO> funcionariosOp = await repoFuncionario.ObtenerTodosActivosSegunMOP(modelo);

            List<PlanificacionDiariaDTO> planificacionesDTO = await repoEscalafon.ObtenerPlanificacionesSegunMesaEnFecha(modelo);
            List<PlanificacionDiariaDTO> auxEstados = new();

            EscalafonModel escalafonModel = new()
            {
                ServiciosDTO = servicios,
                AusenciasDTO = ausencias,
                ClientesDTO = clientes,
                planesDiarios = planificacionesDTO,
                ComputosDTO = computos,
                funcionariosDTO = null
            };

            return Ok(escalafonModel);
        }

        [HttpPost("CopiarEscalafon")]
        public async Task<IActionResult> CopiarEscalafonDiario([FromBody] GeneralTransport modelo)
        {
            GeneralTransport copiaModelo = new()
            {
                Fecha = modelo.FechaFin,
                Valor = modelo.Valor
            };
            //bool existePlanificacionAnterior = await repoEscalafon.ExisteFechaEscalafon(modelo);
            //bool existePlanificacionNuevaCopiar = await repoEscalafon.ExisteFechaEscalafon(copiaModelo);
            //if (!existePlanificacionAnterior && existePlanificacionNuevaCopiar)
            //{
            //    return BadRequest(new ErrorModel("No existe la planificación de la fecha seleccionada o ya existe una planificacion nueva", HttpStatusCode.BadRequest));
            //}
            List<ServicioDTO> servicios = await repoServicio.ObtenerTodosActivosSegunMesaOperativa(modelo);
            List<ComputoDTO> computos = await repoEscalafon.ObtenerComputos();
            computos.RemoveAll(rem => rem.NombreDescriptivo == SD.ComputosEnum.BAJA.ToString());
            List<AusenciaDTO> ausencias = await repoAusencia.ObtenerEnFecha(copiaModelo);

            Dictionary<string, ClienteDTO> clientesIteracion = new Dictionary<string, ClienteDTO>();
            List<ClienteDTO> clientes = new List<ClienteDTO>();
            foreach (var servicio in servicios)
            {
                if (!clientesIteracion.ContainsKey(servicio.Cliente.RazonSocial))
                    clientesIteracion.Add(servicio.Cliente.RazonSocial, servicio.Cliente);
            }

            //clientes = clientesIteracion.Select(s => s.Value).ToList();
            clientes = clientesIteracion.Values.ToList().OrderByDescending(d => d.Id).ToList();
            //clientes.OrderByDescending(d => d.Id);
            List<FuncionarioDTO> funcionariosOp = await repoFuncionario.ObtenerTodosActivosSegunMOP(modelo);

            ///crear la copia
            List<PlanificacionDiariaDTO> CopiaPlanificacionesDTO = await repoEscalafon.CopiarEscalafon(modelo, ausencias);

            EscalafonModel escalafonModel = new()
            {
                ServiciosDTO = servicios,
                AusenciasDTO = ausencias,
                ClientesDTO = clientes,
                planesDiarios = CopiaPlanificacionesDTO,
                ComputosDTO = computos,
                funcionariosDTO = funcionariosOp
            };

            return Ok(escalafonModel);
        }

        [HttpPost("AgregarPlanDiario")]
        public async Task<IActionResult> AgregarPlanDiario([FromBody] PlanificacionDiariaDTO modelo)
        {
            try
            {
                PlanificacionDiariaDTO nuevaPlanificacion;
                nuevaPlanificacion = await repoEscalafon.AgregarPlanDiario(modelo);
                return Ok(nuevaPlanificacion);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
            }

        }

        [HttpPost("AgregarFuncionarioEstadoBolsa")]
        public async Task<IActionResult> AgregarFuncionarioEstadoBolsa([FromBody] FuncionarioFecha modelo)
        {
            try
            {
                PlanificacionDiariaDTO plan = await repoEscalafon.AgregarFuncionarioEnBolsa(modelo);
                return Ok(plan);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
            }
        }//**

        [HttpPost("ActualizarPlanDiario")]
        public async Task<IActionResult> ActualizarPlanDiario([FromBody] PlanificacionDiariaDTO modelo)
        {
            try
            {
               if (modelo != null) {
                    PlanificacionDiariaDTO respuestaPlanificacion;
                    respuestaPlanificacion = await repoEscalafon.ActualizarPlanDiario(modelo);
                    return Ok(respuestaPlanificacion);
                }
                return BadRequest(new ErrorModel("no se ha podido procesar, faltan datos", HttpStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
            }

        }


        [HttpPost("AgregarNombrePuesto")]
        public async Task<IActionResult> AgregarNombrePuesto([FromBody] NombrePuestoDTO modelo)
        {
            try
            {
                if (modelo == null)
                {
                    return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
                }
                NombrePuestoDTO np = await repoEscalafon.AgregarNombrePuesto(modelo);
                if (np == null)
                {
                    return BadRequest(new ErrorModel("No se pudo registrar el nombre de puesto", HttpStatusCode.BadRequest));
                }
                return Ok(np);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
            }

        }

        [HttpPost("ObtenerNombresPuestos")]
        public async Task<IActionResult> ObtenerNombresPuestos([FromBody] GeneralTransport modelo)
        {
            try
            {
                if (modelo == null)
                {
                    return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
                }
                List<NombrePuestoDTO> np = await repoEscalafon.ObtenerNombresPuestos(modelo);
               
                return Ok(np);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
            }

        }

        [HttpPost("EliminarEstado")]
        public async Task<IActionResult> EliminarEstado(PlanificacionDiariaDTO modelo) 
        {
            try
            {
                if (modelo == null)
                {
                    return BadRequest(new ErrorModel("No hay ningun id seleccionado", HttpStatusCode.BadRequest));
                }
                PlanificacionDiariaDTO resultado = await repoEscalafon.EliminarPlanDiario(modelo);
                if (resultado == null)
                {
                    return BadRequest(new ErrorModel("No se pudo eliminar el estado", HttpStatusCode.BadRequest));
                }
                return Ok(resultado);
            }catch(Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
            }

        }

        [HttpPost("ImportarCliServ")]
        public async Task<IActionResult> ImportarClientesYServicios([FromBody] ClientesServiciosImport modelo)
        {
            try
            {
                if (modelo == null)
                {
                    return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
                }
                bool registro = await repoEscalafon.ImportarClientesYServicios(modelo);

                return Ok(registro);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
            }

        }

        [HttpPost("ObtenerPlanificacionPorServicio")]
        public async Task<IActionResult> ObtenerPlanificacionPorServicio([FromBody] VisorHistorialServicio modelo)
        {
            try
            {
                if (modelo == null)
                {
                    return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
                }
                List<PlanificacionDiariaDTO> planes = await repoEscalafon.ObtenerPlanificacionesEnServicio(modelo);
                if (planes == null)
                {
                    return BadRequest(new ErrorModel("No se pudo registrar el nombre de puesto", HttpStatusCode.BadRequest));
                }
                return Ok(planes);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
            }

        }

        [HttpPost("AusenciasGantt")]
        public async Task<IActionResult> AusenciasGantt([FromBody] FiltroGantt modelo)
        {
            try
            {
                if (modelo == null)
                {
                    return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
                }
                List<GanttModel> ganttModel = await repoAusencia.ObtenerPeriodoAusenciasVigentes(modelo);
                if (ganttModel == null)
                {
                    return BadRequest(new ErrorModel("No se pudo acceder a las ausnecias", HttpStatusCode.BadRequest));
                }
                return Ok(ganttModel);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
            }

        }





    }
}
