using AccesoDatos;
using AutoMapper;
using Comun;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.OtherModels;
using Modelo.ViewModels;
using Negocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negocio.Repositorios
{
    public class RepoPlanificacionEscalafon
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;
        private readonly IRepoAusencia repoAusencia;
        private readonly RepoPlanificacionDiaria repoPlanificacionDiaria;

        public RepoPlanificacionEscalafon(AppDbContext _db, IMapper _mapper, IRepoAusencia _repoAusencia, RepoPlanificacionDiaria _repoPlanificacionDiaria)
        {
            db = _db;
            mapper = _mapper;
            repoAusencia = _repoAusencia;
            repoPlanificacionDiaria = _repoPlanificacionDiaria;
        }
        public async Task<bool> ExisteFechaEscalafon(GeneralTransport modelo)
        {
            try
            {
                PlanificacionDiaria busqueda = await db.PlanificacionesDiarias.FirstOrDefaultAsync(f => f.Fecha.Date == modelo.Fecha.Date && 
                                                                                                        f.FuncionarioOperativo.RespondeA.Id == modelo.Valor);
                if (busqueda != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<ComputoDTO> ObtenerComputoPorNombre(string nombre)
        {
            try
            {
                if (string.IsNullOrEmpty(nombre)) return null;

                ComputoDTO computo = mapper.Map<Computo, ComputoDTO>(await db.Computos.FirstOrDefaultAsync(f => f.NombreDescriptivo == nombre));

                return computo;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<ComputoDTO>> ObtenerComputos()
        {
            try
            {
                List<ComputoDTO> computos =
                    mapper.Map<List<Computo>, List<ComputoDTO>>(db.Computos.ToList());

                return computos;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<PlanificacionDiariaDTO>> RegistrarLineasPlanificacion(List<PlanificacionDiariaDTO> planificacionesDTO)
        {
            try
            {
                DateTime fecha = planificacionesDTO[0].Fecha;
                int mesaOperativaId = planificacionesDTO[0].Servicio.DependeDe.Id;
                if (planificacionesDTO == null) return null;
                List<PlanificacionDiaria> planificacionesDiarias = mapper.Map<List<PlanificacionDiariaDTO>, List<PlanificacionDiaria>>(planificacionesDTO);
                Funcionario funcionario = new();
                Computo computo = new();
                Servicio servicio = new();
                foreach (var plan in planificacionesDiarias)
                {
                    funcionario = await db.Funcionarios.FirstOrDefaultAsync(f => f.Id == plan.FuncionarioOperativo.Id);
                    plan.FuncionarioOperativo = funcionario;
                    computo = await db.Computos.FirstOrDefaultAsync(f => f.Id == plan.Computo.Id);
                    plan.Computo = computo;
                    servicio = await db.Servicios.FirstOrDefaultAsync(f => f.Id == plan.Servicio.Id);
                    plan.Servicio = servicio;
                    db.Entry(plan.Servicio).State = EntityState.Unchanged;
                    db.Entry(plan.FuncionarioOperativo).State = EntityState.Unchanged;
                    db.Entry(plan.Computo).State = EntityState.Unchanged;
                    await db.PlanificacionesDiarias.AddRangeAsync(plan);
                }
                int cantidad = await db.SaveChangesAsync();

                planificacionesDiarias = db.PlanificacionesDiarias.Where(w => w.Fecha == fecha &&
                                                                              w.Servicio.DependeDe.Id == mesaOperativaId).ToList();
                planificacionesDTO = mapper.Map<List<PlanificacionDiaria>, List<PlanificacionDiariaDTO>>(planificacionesDiarias);
                return planificacionesDTO;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<bool> ActualizarSoloPlanDiario(PlanificacionDiariaDTO planDiarioDTO)
        {
            try
            {
                PlanificacionDiaria plan = mapper.Map<PlanificacionDiariaDTO, PlanificacionDiaria>(planDiarioDTO);
                db.Entry(plan.FuncionarioOperativo).State = EntityState.Unchanged;
                db.Entry(plan.Servicio).State = EntityState.Unchanged;
                db.Entry(plan.Computo).State = EntityState.Unchanged;
                var update = db.PlanificacionesDiarias.Update(plan);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<AusenciaDTO> RegistrarAusencia(AusenciaDTO ausenciaDTO) //revisar
        {
            try
            {
                if (ausenciaDTO == null)
                {
                    return null;
                }
                    AusenciaDTO ausenciaNueva = await repoAusencia.Agregar(ausenciaDTO);
                    if (ausenciaDTO == null)
                    {
                        return null;
                    }
                    return ausenciaNueva;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<NombrePuestoDTO> AgregarNombrePuesto(NombrePuestoDTO nombrePuestoDTO)
        {
            try
            {
                NombrePuesto np = mapper.Map<NombrePuestoDTO, NombrePuesto>(nombrePuestoDTO);
                db.Entry(np.Servicio).State = EntityState.Unchanged;
                var add = await db.NombresPuestos.AddAsync(np);
                await db.SaveChangesAsync();
                NombrePuestoDTO uFinal = mapper.Map<NombrePuesto, NombrePuestoDTO>(add.Entity);
                return uFinal;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<NombrePuestoDTO>> ObtenerNombresPuestos(GeneralTransport modelo)
        {
            try
            {
                List<NombrePuestoDTO> NombresPuestos = mapper.Map<List<NombrePuesto>, List<NombrePuestoDTO>>(
                                                            db.NombresPuestos.Where(w => w.Servicio.Id == modelo.Valor).ToList());

                return NombresPuestos;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<PlanificacionDiariaDTO>> ObtenerPlanificacionesSegunMesaEnFecha(GeneralTransport modelo)
        {
            try
            {
                List<PlanificacionDiariaDTO> planificacionesDTO =
                    mapper.Map<List<PlanificacionDiaria>, List<PlanificacionDiariaDTO>>(db.PlanificacionesDiarias
                                                                    .Include(i => i.Computo)
                                                                    .Include(i => i.FuncionarioOperativo.TipoContrato)
                                                                    .Include(i => i.FuncionarioOperativo.RespondeA)
                                                                    .Include(i => i.Servicio)
                                                                    .Where(w => w.IdMesaOperativa == modelo.Valor &&
                                                                                w.Fecha == modelo.Fecha &&
                                                                                w.Servicio.GuardiaFisica == true).ToList());
                return planificacionesDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PlanificacionDiariaDTO>> CopiarEscalafon(GeneralTransport modelo, List<AusenciaDTO> ausencias)
        {
            //tambien deberia evaluar si el funcionario está en otra mesa operativa
            try
            {
                List<PlanificacionDiariaDTO> CopiaPlanificacionesDTO = await ObtenerPlanificacionesSegunMesaEnFecha(modelo);
                Computo auxComputo = await db.Computos.SingleOrDefaultAsync(s => s.NombreDescriptivo == SD.ComputosEnum.BAJA.ToString());
                ComputoDTO computoBAJA = new();
                computoBAJA = auxComputo != null ? mapper.Map<Computo, ComputoDTO>(auxComputo) : computoBAJA;

                TimeSpan difFechas = modelo.FechaFin - modelo.Fecha;
                int cantidadDias = difFechas.Days;

                CopiaPlanificacionesDTO.ForEach(f =>
                {
                    f.Id = 0;
                    f.Fecha = modelo.FechaFin;
                    f.HoraEntrada = f.HoraEntrada.AddDays(cantidadDias);
                    f.HoraSalida = f.HoraSalida.AddDays(cantidadDias);

                    if ((f.FuncionarioOperativo.EstadoActividad == SD.EstadoFuncionarioEnum.BAJA_DEFINITIVA.ToString() ||
                        f.FuncionarioOperativo.EstadoActividad == SD.EstadoFuncionarioEnum.BAJA_PARA_LIQUIDACION.ToString()) &&
                        computoBAJA != null)
                    {
                        f.Computo = computoBAJA;
                    }
                });

                //se modifica el computo de los funcionarios que tengan ausencias asociadas (sin contar las bajas)
                List<PlanificacionDiariaDTO> auxEstados = new();

                ausencias.ForEach(ausente =>
                {
                    auxEstados = CopiaPlanificacionesDTO.Where(f => f.FuncionarioOperativo.Id == ausente.Funcionario.Id).ToList();
                    int cantidadEstados = auxEstados.Count;
                    if (cantidadEstados > 0)
                    {
                        for (int i = 0; i < cantidadEstados; i++)
                        {
                            auxEstados[i].Computo = ausente.Computo;
                        }
                    }
                });

                //agregando rotativos que no están en la copia original
                Dictionary<int, FuncionarioDTO> hashRotativos = new();

                List<Funcionario> Fr = db.Funcionarios.Include(i => i.RespondeA)
                                                                        .Include(i => i.TipoContrato)
                                                                        .Include(i => i.Rubro)
                                                                        .Where(w => w.EstadoActividad == SD.EstadoFuncionarioEnum.ACTIVO.ToString() &&
                                                                                    w.RespondeA.Id == modelo.Valor &&
                                                                                    w.Rotativo == true)
                                                                         .ToList();


                List<FuncionarioDTO> FunRotativosTodos = mapper.Map<List<Funcionario>, List<FuncionarioDTO>>(Fr);

                FunRotativosTodos.ForEach(f =>
                {
                    hashRotativos.Add(f.Id, f);
                });

                List<PlanificacionDiariaDTO> estadosAuxRotativos = CopiaPlanificacionesDTO.Where(w => w.Rotativo == true).ToList();

                estadosAuxRotativos.ForEach(f =>
                {
                    if (hashRotativos.ContainsKey(f.FuncionarioOperativo.Id))
                    {
                        hashRotativos[f.FuncionarioOperativo.Id] = null;
                    }
                });

                List<FuncionarioDTO> filtroFunRotativosFaltanes = hashRotativos.Where(w => w.Value != null)
                                                                                        .Select(s => s.Value).ToList();

                if (filtroFunRotativosFaltanes != null)
                {
                    if (filtroFunRotativosFaltanes.Count > 0)
                    {
                        List<PlanificacionDiariaDTO> nuevosEstadosRotativosBosla = new();
                        ComputoDTO computoDTOSJ = mapper.Map<Computo, ComputoDTO>(await db.Computos.AsNoTracking()
                                                                                                    .SingleOrDefaultAsync(s => s.NombreDescriptivo == SD.SinJornalAsignado));
                        filtroFunRotativosFaltanes.ForEach(f =>
                        {
                            PlanificacionDiariaDTO nuevo = new()
                            {
                                Id = 0,
                                Fecha = modelo.FechaFin,
                                Computo = computoDTOSJ,
                                FuncionarioOperativo = f,
                                Servicio = CopiaPlanificacionesDTO[0].Servicio,
                                HoraEntrada = modelo.FechaFin,
                                HoraSalida = modelo.FechaFin,
                                Rotativo = f.Rotativo,
                                TipoResumido = f.TipoResumido,
                                IdMesaOperativa = modelo.Valor,
                                TipoFuncionarioOperativo = SD.TipoFuncionarioOperativo["CIVIL"],
                                Turno = 1
                            };
                            nuevosEstadosRotativosBosla.Add(nuevo);
                        });
                        CopiaPlanificacionesDTO.AddRange(nuevosEstadosRotativosBosla);
                    }
                }
                //****************************   Registro de copia de planificaciones ****************************************

                List<PlanificacionDiaria> copiaPlanificaciones = mapper.Map<List<PlanificacionDiariaDTO>, List<PlanificacionDiaria>>(CopiaPlanificacionesDTO);
                Funcionario funcionario = new();
                Computo computo = new();
                Servicio servicio = new();

                foreach (var plan in copiaPlanificaciones)
                {
                    funcionario = await db.Funcionarios.FirstOrDefaultAsync(f => f.Id == plan.FuncionarioOperativo.Id);
                    plan.FuncionarioOperativo = funcionario;
                    computo = await db.Computos.FirstOrDefaultAsync(f => f.Id == plan.Computo.Id);
                    plan.Computo = computo;
                    servicio = await db.Servicios.FirstOrDefaultAsync(f => f.Id == plan.Servicio.Id);
                    plan.Servicio = servicio;
                    db.Entry(plan.Servicio).State = EntityState.Unchanged;
                    db.Entry(plan.FuncionarioOperativo).State = EntityState.Unchanged;
                    db.Entry(plan.Computo).State = EntityState.Unchanged;
                    await db.PlanificacionesDiarias.AddRangeAsync(plan);
                }
                int cantidad = await db.SaveChangesAsync();

                copiaPlanificaciones = db.PlanificacionesDiarias
                                                                .Include(i => i.Computo)
                                                                .Include(i => i.FuncionarioOperativo.TipoContrato)
                                                                .Include(i => i.FuncionarioOperativo.RespondeA)
                                                                .Include(i => i.Servicio)
                                                                .Where(w => w.Fecha == modelo.FechaFin &&
                                                                            w.Servicio.DependeDe.Id == modelo.Valor).ToList();
                CopiaPlanificacionesDTO = mapper.Map<List<PlanificacionDiaria>, List<PlanificacionDiariaDTO>>(copiaPlanificaciones);
                return CopiaPlanificacionesDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ImportarClientesYServicios(ClientesServiciosImport modelo)
        {
            try
            {
                List<Cliente> clientes = mapper.Map<List<ClienteDTO>, List<Cliente>>(modelo.ClientesDTO);
                List<Servicio> servicios = mapper.Map<List<ServicioImport>, List<Servicio>>(modelo.ServiciosImport);

                await db.Clientes.AddRangeAsync(clientes);
                await db.SaveChangesAsync();

                List<Cliente> clientesBD = db.Clientes.ToList();
                List<MesaOperativa> mopsBD = db.MesasOperativas.ToList();

                foreach (var servicio in servicios)
                {
                    servicio.Cliente = clientesBD.SingleOrDefault(s => s.RazonSocial == servicio.Cliente.RazonSocial);
                    servicio.DependeDe = mopsBD.SingleOrDefault(s => s.Id == servicio.DependeDe.Id);
                    db.Entry(servicio.Cliente).State = EntityState.Unchanged;
                    db.Entry(servicio.DependeDe).State = EntityState.Unchanged;
                    await db.Servicios.AddAsync(servicio);
                }
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error");
            }
        }

        private async Task<ConteoHorarioEstado> ConteoHorario(List<PlanificacionDiariaDTO> estados,PlanificacionDiariaDTO plan)
        {
            try
            {
            ConteoHorarioEstado conteo = new();

                List<PlanificacionDiariaDTO> estadosEnServicioActual = estados.Where(w => w.Servicio.Id == plan.Servicio.Id).ToList();
                decimal horasContrato = decimal.Round(Convert.ToDecimal(plan.FuncionarioOperativo.TipoContrato.CargaTrabajoDiaria), 2);
                TimeSpan tiempo = plan.HoraSalida.Subtract(plan.HoraEntrada).Duration();
                decimal totalHorasTrabajadas = decimal.Round(Convert.ToDecimal(tiempo.TotalMinutes / 60), 2);

                int cantidadEstados = estadosEnServicioActual.Count();
                decimal horasExtras = -1;

                if (cantidadEstados == 0)
                {
                    horasExtras = totalHorasTrabajadas > horasContrato ? totalHorasTrabajadas-horasContrato : 0;
                }
                else
                {
                    decimal sumaTotales = decimal.Round(Convert.ToDecimal(estadosEnServicioActual.Sum(s => s.CantidadHorasTotales)),2) + totalHorasTrabajadas;
                    decimal sumaExtras = decimal.Round(Convert.ToDecimal(estadosEnServicioActual.Sum(s => s.CantidadHorasExtras)),2);
                    decimal diferenciaSumas = sumaTotales - sumaExtras;
                    horasExtras = diferenciaSumas > horasContrato ? diferenciaSumas - horasContrato : 0;
                }

                conteo.CantidadHorasTotales = Convert.ToDouble(totalHorasTrabajadas);
                conteo.CantidadHorasExtras = Convert.ToDouble(horasExtras);
            
                return conteo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PlanificacionDiariaDTO> AgregarFuncionarioEnBolsa(FuncionarioFecha funcionarioFecha)
        {
            try 
            {
                if (funcionarioFecha == null)
                {
                    throw new Exception("El estado no existe. Error 127");
                }

                PlanificacionDiariaDTO plan = await repoPlanificacionDiaria.AgregarFuncionarioEnBolsa(funcionarioFecha);
                plan.ModalidadActualizacionBolsa = SD.ModalidadActualizacion.AGREGAR.ToString();
                plan.ModalidadActualizacionEscalafon = "";
                return plan;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ExisteChoqueHorario(List<PlanificacionDiariaDTO> estados, PlanificacionDiariaDTO planActual)
        {
            int cantidadConChoqueHorario = estados.Count(f =>
               (

               (planActual.HoraEntrada >= f.HoraEntrada && planActual.HoraEntrada <= f.HoraSalida.AddMinutes(-1)) ||
               (planActual.HoraSalida.AddMinutes(-1) >= f.HoraEntrada && planActual.HoraSalida.AddMinutes(-1) <= f.HoraSalida.AddMinutes(-1)) ||
               (planActual.HoraEntrada <= f.HoraEntrada && planActual.HoraSalida.AddMinutes(-1) >= f.HoraSalida.AddMinutes(-1))

               ) &&
               (f.Computo.NombreDescriptivo == SD.ComputosEnum.NORMAL.ToString() ||
                f.Computo.NombreDescriptivo == SD.ComputosEnum.LIBRE_TRABAJADO.ToString().Replace("_"," ")
               )
             );

            if (cantidadConChoqueHorario == 0) return false;

            return true;
        }

       
        //Operaciones sobre escalafon ***********************************************************************************************


        public async Task<PlanificacionDiariaDTO> AgregarPlanDiario(PlanificacionDiariaDTO planDTO)
        {
            try
            {
                DateTime entrada = planDTO.Fecha.AddHours(planDTO.HoraEntrada.Hour).AddMinutes(planDTO.HoraEntrada.Minute);
                DateTime salida = planDTO.Fecha.AddHours(planDTO.HoraSalida.Hour).AddMinutes(planDTO.HoraSalida.Minute);

                planDTO.HoraEntrada = entrada;
                planDTO.HoraSalida = salida;

                if (planDTO.HoraEntrada > planDTO.HoraSalida && !planDTO.CorrespondeAlDiaSiguiente)
                {
                    planDTO.HoraSalida = planDTO.HoraSalida.AddDays(1);
                }

                if (planDTO.CorrespondeAlDiaSiguiente)
                {
                    planDTO.HoraEntrada = planDTO.HoraEntrada.AddDays(1);
                    planDTO.HoraSalida = planDTO.HoraSalida.AddDays(1);

                    if (planDTO.HoraEntrada > planDTO.HoraSalida)
                        throw new Exception("Si asigna un horario posterior a la fecha la hora de entrada debe ser menor a la hora de salida");
                }

                PlanificacionDiariaDTO nuevoActualizarEstadoDTO = null;
                AusenciaDTO registroAusenciaDTO = null;
                ConteoHorarioEstado conteo = null;

                List<PlanificacionDiariaDTO> estadosEnRango = await repoPlanificacionDiaria.ObtenerEstadosRangoFechaSegunFuncionario(planDTO);
                List<PlanificacionDiariaDTO> estados = estadosEnRango.Where(w => w.Fecha == planDTO.Fecha).ToList();
                int cantidadEstados = estados.Count();

                planDTO.Rotativo = planDTO.FuncionarioOperativo.Rotativo;
                planDTO.TipoResumido = planDTO.FuncionarioOperativo.TipoResumido;

                if (estados.Count(c => c.ComienzoJornada == true) > 0 && planDTO.ComienzoJornada == true)
                    throw new Exception("Solo puede haber un comienzo de jornada por dia");

                if (SD.ComputaAusencia[planDTO.Computo.NombreDescriptivo])
                {

                    planDTO.AusenciaDTO.Computo = planDTO.Computo;
                    planDTO.AusenciaDTO.Funcionario = planDTO.FuncionarioOperativo;
                    planDTO.AusenciaDTO.Servicio = planDTO.Servicio;

                    if (planDTO.FuncionarioOperativo.Rotativo)
                    {
                        List<string> ausenciasWords = new();

                        int ausenciaRegistrada = estados.Count(c => SD.ComputaAusencia[c.Computo.NombreDescriptivo] == true); //version2

                        if (ausenciaRegistrada > 0)
                            throw new Exception("Hay otra ausencia registrada para el funcionario especificado");


                        if (cantidadEstados == 1 && estados[0].Computo.NombreDescriptivo == SD.SinJornalAsignado)
                        {
                            registroAusenciaDTO = await RegistrarAusencia(planDTO.AusenciaDTO);
                            estados[0].Computo = planDTO.Computo;
                            nuevoActualizarEstadoDTO = await repoPlanificacionDiaria.ActualizarPlanDiario(estados[0]);
                            nuevoActualizarEstadoDTO.ModalidadActualizacionBolsa = SD.ModalidadActualizacion.ACTUALIZAR.ToString();
                        }
                        else
                        {
                            throw new Exception("No se puede registrar una ausencia sin liberar al funcionario especificado");
                        }
                    }
                    else
                    {
                        if (cantidadEstados > 0) throw new Exception("No se puede registrar una ausencia porque hay otro/s estado/s en el escalafon");

                        registroAusenciaDTO = await RegistrarAusencia(planDTO.AusenciaDTO);
                        nuevoActualizarEstadoDTO = await repoPlanificacionDiaria.AgregarPlanDiario(planDTO);
                        nuevoActualizarEstadoDTO.ModalidadActualizacionBolsa = SD.ModalidadActualizacion.AGREGAR.ToString();
                    }
                    if (nuevoActualizarEstadoDTO == null) throw new Exception("No se ha podido registrar el estado");

                    nuevoActualizarEstadoDTO.AusenciaDTO = registroAusenciaDTO;
                    nuevoActualizarEstadoDTO.ModalidadActualizacionEscalafon = SD.ModalidadActualizacion.AGREGAR.ToString();
                    return nuevoActualizarEstadoDTO;
                }

                //si planDTO es NORMAL o LIBRE TRABAJADO
                if (estados.Count(c => c.Computo.NombreDescriptivo == SD.ComputosEnum.LIBRE.ToString()) > 0)
                    throw new Exception("Solo puede computar un libre por dia de planificación");

                if (cantidadEstados > 0) {
                    if (ExisteChoqueHorario(estadosEnRango, planDTO))
                        throw new Exception("No se puede registrar el estado ya que existe choque horario con otro estado");

                    if (estados[0].Computo.NombreDescriptivo != planDTO.Computo.NombreDescriptivo &&
                  estados[0].Computo.NombreDescriptivo != SD.SinJornalAsignado)
                        throw new Exception("No se puede registrar el estado. Debe guardar coherencia en la carga");
                }
                if (planDTO.FuncionarioOperativo.Rotativo)
                {
                    if (cantidadEstados == 1 && estados[0].Computo.NombreDescriptivo == SD.SinJornalAsignado)
                    {
                        PlanificacionDiariaDTO estadoEnBolsa = estados[0];

                        //copio datos del plan que quiero agregar
                        estadoEnBolsa.ComienzoJornada = planDTO.ComienzoJornada;
                        estadoEnBolsa.CantidadHorasTotales = planDTO.CantidadHorasTotales;
                        estadoEnBolsa.Computo = planDTO.Computo;
                        estadoEnBolsa.Extra = planDTO.Extra;
                        estadoEnBolsa.Facturable = planDTO.Facturable;
                        estadoEnBolsa.HoraEntrada = planDTO.HoraEntrada;
                        estadoEnBolsa.HoraSalida = planDTO.HoraSalida;
                        estadoEnBolsa.NombrePuesto = planDTO.NombrePuesto;
                        estadoEnBolsa.Orden = planDTO.Orden;
                        estadoEnBolsa.SegundoNivel = planDTO.SegundoNivel;
                        estadoEnBolsa.Servicio = planDTO.Servicio;
                        estadoEnBolsa.TipoPuesto = planDTO.TipoPuesto;
                        estadoEnBolsa.Turno = planDTO.Turno;
                        estadoEnBolsa.MostrarEnEscalafon = true;
                        estadoEnBolsa.CantidadHorasArmado = planDTO.CantidadHorasArmado;
                        conteo = await ConteoHorario(estados,estadoEnBolsa);
                        estadoEnBolsa.CantidadHorasTotales = conteo.CantidadHorasTotales;
                        estadoEnBolsa.CantidadHorasExtras = conteo.CantidadHorasExtras;
                        estadoEnBolsa.FuncionarioSegundoNivel = "";

                        if (estadoEnBolsa.CantidadHorasArmado > estadoEnBolsa.CantidadHorasTotales)
                            throw new Exception("Las horas de armado excede de la cantidad de horas totales asignadas. Revise");

                        nuevoActualizarEstadoDTO = await repoPlanificacionDiaria.ActualizarPlanDiario(estadoEnBolsa);
                        nuevoActualizarEstadoDTO.ModalidadActualizacionEscalafon = SD.ModalidadActualizacion.AGREGAR.ToString();
                        nuevoActualizarEstadoDTO.ModalidadActualizacionBolsa = SD.ModalidadActualizacion.ACTUALIZAR.ToString();
                        if (nuevoActualizarEstadoDTO == null) throw new Exception("No se ha podido agregar el estado. Verifique");
                    }
                    else
                    {
                        planDTO.Observaciones = $"{estados[0].Observaciones} - {planDTO.Observaciones}";
                        planDTO.HoySegundoLibre = estados[0].HoySegundoLibre;
                        planDTO.Rotativo = planDTO.FuncionarioOperativo.Rotativo;
                        planDTO.TipoResumido = planDTO.FuncionarioOperativo.TipoResumido;
                        conteo = await ConteoHorario(estados, planDTO);
                        planDTO.CantidadHorasTotales = conteo.CantidadHorasTotales;
                        planDTO.CantidadHorasExtras = conteo.CantidadHorasExtras;

                        if (planDTO.CantidadHorasArmado > planDTO.CantidadHorasTotales)
                            throw new Exception("Las horas de armado excede de la cantidad de horas totales asignadas. Revise");

                        nuevoActualizarEstadoDTO = await repoPlanificacionDiaria.AgregarPlanDiario(planDTO);
                        nuevoActualizarEstadoDTO.ModalidadActualizacionEscalafon = SD.ModalidadActualizacion.AGREGAR.ToString();
                        nuevoActualizarEstadoDTO.ModalidadActualizacionBolsa = SD.ModalidadActualizacion.AGREGAR.ToString();
                    }
                }
                else
                {
                    conteo = await ConteoHorario(estados, planDTO);
                    planDTO.CantidadHorasTotales = conteo.CantidadHorasTotales;
                    planDTO.CantidadHorasExtras = conteo.CantidadHorasExtras;
                    nuevoActualizarEstadoDTO = await repoPlanificacionDiaria.AgregarPlanDiario(planDTO);
                    nuevoActualizarEstadoDTO.ModalidadActualizacionEscalafon = SD.ModalidadActualizacion.AGREGAR.ToString();
                    nuevoActualizarEstadoDTO.ModalidadActualizacionBolsa = "";
                }
                return nuevoActualizarEstadoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PlanificacionDiariaDTO> ActualizarPlanDiario(PlanificacionDiariaDTO planDTO)
        {
            try
            {
                DateTime entrada = planDTO.Fecha.AddHours(planDTO.HoraEntrada.Hour).AddMinutes(planDTO.HoraEntrada.Minute);
                DateTime salida = planDTO.Fecha.AddHours(planDTO.HoraSalida.Hour).AddMinutes(planDTO.HoraSalida.Minute);

                planDTO.HoraEntrada = entrada;
                planDTO.HoraSalida = salida;

                if (planDTO.HoraEntrada > planDTO.HoraSalida && !planDTO.CorrespondeAlDiaSiguiente)
                {
                    planDTO.HoraSalida = planDTO.HoraSalida.AddDays(1);
                }

                if (planDTO.CorrespondeAlDiaSiguiente)
                {
                    planDTO.HoraEntrada = planDTO.HoraEntrada.AddDays(1);
                    planDTO.HoraSalida = planDTO.HoraSalida.AddDays(1);

                    if (planDTO.HoraEntrada > planDTO.HoraSalida)
                        throw new Exception("Si asigna un horario posterior a la fecha la hora de entrada debe ser menor a la hora de salida");
                }

                PlanificacionDiariaDTO nuevoActualizarEstadoDTO = null;
                AusenciaDTO registroAusenciaDTO = null;
                ConteoHorarioEstado conteo = null;

                List<PlanificacionDiariaDTO> estadosEnRango = await repoPlanificacionDiaria.ObtenerEstadosRangoFechaSegunFuncionario(planDTO);
                List<PlanificacionDiariaDTO> estados = estadosEnRango.Where(w => w.Fecha == planDTO.Fecha).ToList();
                int cantidadEstados = estados.Count();

                planDTO.Rotativo = planDTO.FuncionarioOperativo.Rotativo;
                planDTO.TipoResumido = planDTO.FuncionarioOperativo.TipoResumido;

                if (estados.Count(c => c.ComienzoJornada == true) > 0 && planDTO.ComienzoJornada == true)
                    throw new Exception("Solo puede haber un comienzo de jornada por dia");

                if (SD.ComputaAusencia[planDTO.Computo.NombreDescriptivo])
                {
                    planDTO.AusenciaDTO.Computo = planDTO.Computo;
                    planDTO.AusenciaDTO.Funcionario = planDTO.FuncionarioOperativo;
                    planDTO.AusenciaDTO.Servicio = planDTO.Servicio;

                    int ausenciaRegistrada = estados.Count(c => SD.ComputaAusencia[c.Computo.NombreDescriptivo] == true); //version2

                    if (ausenciaRegistrada > 0)
                        throw new Exception("Hay otra ausencia registrada para el funcionario especificado");


                    if (cantidadEstados > 0) throw new Exception("No se puede registrar una ausencia porque hay otro/s estado/s en el escalafon");

                    registroAusenciaDTO = await RegistrarAusencia(planDTO.AusenciaDTO);
                    nuevoActualizarEstadoDTO = await repoPlanificacionDiaria.ActualizarPlanDiario(planDTO);
                    nuevoActualizarEstadoDTO.ModalidadActualizacionBolsa = SD.ModalidadActualizacion.ACTUALIZAR.ToString();

                    if (nuevoActualizarEstadoDTO == null) throw new Exception("No se ha podido registrar el estado");

                    nuevoActualizarEstadoDTO.AusenciaDTO = registroAusenciaDTO;
                    nuevoActualizarEstadoDTO.ModalidadActualizacionEscalafon = SD.ModalidadActualizacion.ACTUALIZAR.ToString();
                    return nuevoActualizarEstadoDTO;
                }

                //si planDTO es NORMAL o LIBRE TRABAJADO

                if (cantidadEstados > 0)
                {
                    //if (estados.Count(c => c.Computo.NombreDescriptivo == SD.ComputosEnum.LIBRE.ToString()) > 0 &&
                    //    planDTO.Computo.NombreDescriptivo == SD.ComputosEnum.LIBRE.ToString())
                    //    throw new Exception("Solo puede computar un libre por dia de planificación");

                    if (ExisteChoqueHorario(estadosEnRango, planDTO))
                        throw new Exception("No se puede registrar el estado ya que existe choque horario con otro estado");


                    if (estados[0].Computo.NombreDescriptivo != planDTO.Computo.NombreDescriptivo)
                        throw new Exception("No se puede registrar el estado. Debe guardar coherencia en la carga");
                    
                }

                conteo = await ConteoHorario(estados, planDTO);
                planDTO.CantidadHorasTotales = conteo.CantidadHorasTotales;
                planDTO.CantidadHorasExtras = conteo.CantidadHorasExtras;

                nuevoActualizarEstadoDTO = await repoPlanificacionDiaria.ActualizarPlanDiario(planDTO);
                nuevoActualizarEstadoDTO.ModalidadActualizacionBolsa = SD.ModalidadActualizacion.ACTUALIZAR.ToString();
                nuevoActualizarEstadoDTO.ModalidadActualizacionEscalafon = SD.ModalidadActualizacion.ACTUALIZAR.ToString();
                if (nuevoActualizarEstadoDTO == null) throw new Exception("No se ha podido agregar el estado. Verifique");
                   
                return nuevoActualizarEstadoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PlanificacionDiariaDTO> EliminarPlanDiario(PlanificacionDiariaDTO planDTO)
        {
            try
            {
                PlanificacionDiariaDTO actualizarEstadoDTO = null;

                List<PlanificacionDiariaDTO> estadosEnRango = await repoPlanificacionDiaria.ObtenerEstadosRangoFechaSegunFuncionario(planDTO);
                List<PlanificacionDiariaDTO> estados = estadosEnRango.Where(w => w.Fecha == planDTO.Fecha).ToList();
                int cantidadEstados = estados.Count();


                if (SD.ComputaAusencia[planDTO.Computo.NombreDescriptivo] && planDTO.Computo.NombreDescriptivo != SD.ComputosEnum.BAJA.ToString())
                {
                    throw new Exception("No se puede eliminar esta ausencia");
                }

                //si planDTO es NORMAL o LIBRE TRABAJADO
             
                    if (cantidadEstados == 0 && planDTO.Rotativo)
                {
                    planDTO.MostrarEnEscalafon = false;
                    planDTO.ComienzoJornada = false;
                    planDTO.Computo = mapper.Map<Computo,ComputoDTO>(await db.Computos.AsNoTracking().SingleOrDefaultAsync(s => s.NombreDescriptivo == SD.SinJornalAsignado));

                    actualizarEstadoDTO = await repoPlanificacionDiaria.ActualizarPlanDiario(planDTO);
                    actualizarEstadoDTO.ModalidadActualizacionBolsa = SD.ModalidadActualizacion.ACTUALIZAR.ToString();
                }
                else
                {
                    bool eliminado = await repoPlanificacionDiaria.EliminarPlanDiario(planDTO);
                    if (!eliminado)
                        throw new Exception("No se pudo eliminar");
                    actualizarEstadoDTO = planDTO;
                    actualizarEstadoDTO.ModalidadActualizacionBolsa = SD.ModalidadActualizacion.ELIMINAR.ToString();
                }
                actualizarEstadoDTO.ModalidadActualizacionEscalafon = SD.ModalidadActualizacion.ELIMINAR.ToString();
                return actualizarEstadoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PlanificacionDiariaDTO>> ObtenerPlanificacionesEnServicio(VisorHistorialServicio visorDTO)
        {
            try
            {
                List<PlanificacionDiariaDTO> estadosServicioDia = await repoPlanificacionDiaria.ObtenerPlanificacionesEnServicio(visorDTO);
                
                return estadosServicioDia;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public async Task<bool> EliminarFuncionarioEnBolsa(PlanificacionDiariaDTO estadoRotativo)
        //{
        //    try
        //    {
        //        if (estadoRotativo == null)
        //        {
        //            throw new Exception("El estado no existe. Error 127");
        //        }
        //        bool estadoRotativoEliminado = await repoPlanificacionDiaria.EliminarPlanDiarioEnBolsa(estadoRotativo);
        //        return estadoRotativoEliminado;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}









    }
}
