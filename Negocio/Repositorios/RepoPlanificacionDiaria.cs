using AccesoDatos;
using AutoMapper;
using Comun;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.OtherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorios
{
    public class RepoPlanificacionDiaria
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public RepoPlanificacionDiaria(AppDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
            
        }

        public async Task<List<PlanificacionDiariaDTO>> EstadosSegunFuncionario(PlanificacionDiariaDTO estado)
        {
            List<PlanificacionDiaria> estadosBuscado = await db.PlanificacionesDiarias
                                                        .Include(i => i.FuncionarioOperativo)
                                                        .Include(i => i.FuncionarioOperativo.TipoContrato)
                                                        .Include(i => i.FuncionarioOperativo.RespondeA)
                                                        .Include(i => i.FuncionarioOperativo.Rubro)
                                                        .Include(i => i.Computo)
                                                        .Include(i => i.Servicio)
                                                        .Include(i => i.Servicio.Cliente)
                                                        .Include(i => i.Servicio.DependeDe)
                                                        .Where(w => w.Fecha.Date == estado.Fecha.Date &&
                                                                    w.FuncionarioOperativo.Id == estado.FuncionarioOperativo.Id)
                                                        .ToListAsync();

            return mapper.Map<List<PlanificacionDiaria>, List<PlanificacionDiariaDTO>>(estadosBuscado);

        }
        public async Task<List<PlanificacionDiariaDTO>> ObtenerEstadosRangoFechaSegunFuncionario(PlanificacionDiariaDTO planDTO)
        {
            DateTime fechaAnterior = planDTO.Fecha.AddDays(-3);
            DateTime fechaPosterior = planDTO.Fecha.AddDays(3);


            List<PlanificacionDiaria> estadosBuscado = await db.PlanificacionesDiarias
                                                       .Include(i => i.FuncionarioOperativo)
                                                       .Include(i => i.FuncionarioOperativo.TipoContrato)
                                                       .Include(i => i.FuncionarioOperativo.RespondeA)
                                                       .Include(i => i.FuncionarioOperativo.Rubro)
                                                       .Include(i => i.Computo)
                                                       .Include(i => i.Servicio)
                                                       .Include(i => i.Servicio.Cliente)
                                                       .Include(i => i.Servicio.DependeDe)
                                                       .AsNoTracking()
                                                       .Where(w => w.Fecha >= fechaAnterior && w.Fecha <= fechaPosterior &&
                                                                   w.Id != planDTO.Id &&
                                                                   w.FuncionarioOperativo.Id == planDTO.FuncionarioOperativo.Id
                                                                   )
                                                       .ToListAsync();

            return mapper.Map<List<PlanificacionDiaria>, List<PlanificacionDiariaDTO>>(estadosBuscado);
        }

        public async Task<PlanificacionDiariaDTO> AgregarFuncionarioEnBolsa(FuncionarioFecha funcionarioFecha) //revisar
        {
            try
            {
                List<PlanificacionDiaria> estados = db.PlanificacionesDiarias.Where(w => w.FuncionarioOperativo.Id == funcionarioFecha.FuncionarioDto.Id &&
                                                                              w.Fecha == funcionarioFecha.Fecha &&
                                                                              w.IdMesaOperativa == funcionarioFecha.FuncionarioDto.RespondeA.Id).ToList();

                int cantidadEstadosEnEscalafon = estados.Count();

                int cantEstadosfuncionarioEnBolsa = cantidadEstadosEnEscalafon > 0 ? estados.Count(w => w.Rotativo == true) : 0;

                

                if (cantEstadosfuncionarioEnBolsa > 0) 
                    throw new Exception("Para agregar un estado en bolsa el funcionario no puede tener otro estado. Err 260");

                if (cantidadEstadosEnEscalafon > 0)
                    throw new Exception("No se ha podido agregar el rotativo habiendo un estado en el escalafon con modalidad FIJA. Err 262");


                PlanificacionDiaria nuevoEstado = new()
                {
                    Fecha = funcionarioFecha.Fecha,
                    Orden = Generador.GenerarGUID(),
                    FuncionarioOperativo = mapper.Map<FuncionarioDTO, Funcionario>(funcionarioFecha.FuncionarioDto),
                    HoraEntrada = funcionarioFecha.Fecha.Date,
                    HoraSalida = funcionarioFecha.Fecha.Date,
                    HoraEntradaMarcada = funcionarioFecha.Fecha.Date,
                    HoraSalidaMarcada = funcionarioFecha.Fecha.Date,
                    Computo = db.Computos.FirstOrDefault(f => f.NombreDescriptivo == SD.SinJornalAsignado),
                    TipoResumido = funcionarioFecha.TipoResumido,
                    Servicio = await db.Servicios.FirstOrDefaultAsync(f => f.DependeDe.Id == funcionarioFecha.FuncionarioDto.RespondeA.Id),
                    MostrarEnEscalafon = false,
                    Turno = 6,
                    Facturable = true,
                    ComienzoJornada = false,
                    Observaciones = "---",
                    TipoFuncionarioOperativo = "CIVIL",
                    NombrePuesto = "---",
                    Rotativo = true,
                    IdMesaOperativa = funcionarioFecha.FuncionarioDto.RespondeA.Id
                };
                nuevoEstado.FuncionarioOperativo.TipoResumido = funcionarioFecha.TipoResumido;
                nuevoEstado.FuncionarioOperativo.Rotativo = true;

                //db.Entry(nuevoEstado.FuncionarioOperativo).State = EntityState.Modified;
               
                db.Funcionarios.Attach(nuevoEstado.FuncionarioOperativo);
                db.Entry(nuevoEstado.FuncionarioOperativo).Property(p => p.Rotativo).IsModified = true;
                db.Entry(nuevoEstado.FuncionarioOperativo).Property(p => p.TipoResumido).IsModified = true;

                db.Entry(nuevoEstado.Servicio).State = EntityState.Unchanged;
                db.Entry(nuevoEstado.Computo).State = EntityState.Unchanged;
                nuevoEstado.Observaciones = string.IsNullOrEmpty(nuevoEstado.Observaciones) ? "---" : nuevoEstado.Observaciones;

                var add = await db.PlanificacionesDiarias.AddAsync(nuevoEstado);
                await db.SaveChangesAsync();
                PlanificacionDiaria nuevo = add.Entity;
                PlanificacionDiariaDTO uFinal = mapper.Map<PlanificacionDiaria, PlanificacionDiariaDTO>(nuevo);
                return uFinal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //***************************
        public async Task<PlanificacionDiariaDTO> AgregarPlanDiario(PlanificacionDiariaDTO planDTO)
        {
            try
            {
                try
                {
                    PlanificacionDiaria estado = mapper.Map<PlanificacionDiariaDTO, PlanificacionDiaria>(planDTO);
                    if (planDTO.AusenciaDTO != null)
                    {
                        var computo = await db.Computos.FindAsync(estado.Computo.Id);
                        estado.Computo = computo;

                        var funcionario = await db.Funcionarios.FindAsync(estado.FuncionarioOperativo.Id);
                        estado.FuncionarioOperativo = funcionario;

                        var servicio = await db.Servicios.FindAsync(estado.Servicio.Id);
                        estado.Servicio = servicio;
                    }
                    db.Entry(estado.Computo).State = EntityState.Unchanged;
                    db.Entry(estado.FuncionarioOperativo).State = EntityState.Modified;
                    db.Entry(estado.Servicio).State = EntityState.Unchanged;

                    var add = await db.PlanificacionesDiarias.AddAsync(estado);
                    await db.SaveChangesAsync();
                    PlanificacionDiariaDTO uFinal = mapper.Map<PlanificacionDiaria, PlanificacionDiariaDTO>(add.Entity);
                    return uFinal;
                }
                catch (Exception e)
                {
                    return null;
                }
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
                PlanificacionDiaria planDB = await db.PlanificacionesDiarias.SingleOrDefaultAsync(s => s.Id == planDTO.Id);
                PlanificacionDiaria plan = mapper.Map<PlanificacionDiariaDTO, PlanificacionDiaria>(planDTO, planDB);

                if (planDTO.AusenciaDTO != null)
                {
                    var computo = await db.Computos.FindAsync(plan.Computo.Id);
                    plan.Computo = computo;

                    var funcionario = await db.Funcionarios.FindAsync(plan.FuncionarioOperativo.Id);
                    plan.FuncionarioOperativo = funcionario;

                    var servicio = await db.Servicios.FindAsync(plan.Servicio.Id);
                    plan.Servicio = servicio;
                }

                db.Entry(plan.Computo).State = EntityState.Unchanged;
                db.Entry(plan.Servicio).State = EntityState.Unchanged;
                db.Entry(plan.FuncionarioOperativo).State = EntityState.Modified;

                var update = db.PlanificacionesDiarias.Update(plan);
                await db.SaveChangesAsync();
                return mapper.Map<PlanificacionDiaria, PlanificacionDiariaDTO>(update.Entity);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<bool> EliminarPlanDiario(PlanificacionDiariaDTO planDTO)
        {
            // usuario = await db.Usuarios.FindAsync(Id);
            PlanificacionDiaria plan = mapper.Map<PlanificacionDiariaDTO, PlanificacionDiaria>(planDTO);
            db.Entry(plan).State = EntityState.Deleted;
            db.PlanificacionesDiarias.Remove(plan);

            int eliminar = await db.SaveChangesAsync();
            if (eliminar == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<List<PlanificacionDiariaDTO>> ObtenerPlanificacionesEnServicio(VisorHistorialServicio visor)
        {
            List<PlanificacionDiaria> estadosBuscado = await db.PlanificacionesDiarias
                                                       .Include(i => i.FuncionarioOperativo)
                                                       .Include(i => i.Computo)
                                                       .Include(i => i.Servicio)
                                                       .Include(i => i.Servicio.Cliente)
                                                       .Include(i => i.Servicio.DependeDe)
                                                       .AsNoTracking()
                                                       .Where(w => w.Fecha == visor.FechaPlanificacionActual &&
                                                                   w.Servicio.Id == visor.ServicioDTORef.Id)
                                                       .ToListAsync();

            return mapper.Map<List<PlanificacionDiaria>, List<PlanificacionDiariaDTO>>(estadosBuscado);
        }





    }
}
