using AccesoDatos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.OtherModels;
using Modelo.ViewModels;
using Negocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorios
{
    public class RepoAusencia : IRepoAusencia
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public RepoAusencia(AppDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }
        public async Task<AusenciaDTO> Agregar(AusenciaDTO modelo)
        {
            try
            {
                Ausencia ausencia = mapper.Map<AusenciaDTO, Ausencia>(modelo);
                db.Entry(ausencia.Funcionario).State = EntityState.Unchanged;
                db.Entry(ausencia.Computo).State = EntityState.Unchanged;
                db.Entry(ausencia.Servicio).State = EntityState.Unchanged;
                var add = await db.Ausencias.AddAsync(ausencia);
                await db.SaveChangesAsync();
                AusenciaDTO uFinal = mapper.Map<Ausencia, AusenciaDTO>(add.Entity);
                return uFinal;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<AusenciaDTO>> ObtenerEnFecha(GeneralTransport modelo)
        {
            try
            {
                List<AusenciaDTO> ausencias = mapper.Map<List<Ausencia>, List<AusenciaDTO>>(
                                                db.Ausencias
                                                .Include(i => i.Funcionario)
                                                .Include(i => i.Computo)
                                                .Where(w => w.Desde <= modelo.Fecha.Date &&
                                                            w.Hasta >= modelo.Fecha.Date &&
                                                            w.Servicio.DependeDe.Id == modelo.Valor)
                                                .ToList());

                return ausencias;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<GanttModel>> ObtenerPeriodoAusenciasVigentes(FiltroGantt filtroGantt)
        {
            try
            {
                List<GanttModel> dataGanttAusencias = new();
                if (filtroGantt.FechaLimite)
                {

                    dataGanttAusencias = db.Ausencias //un service que traiga todas las ausencias
                        .Where(w => w.Computo.NombreDescriptivo == filtroGantt.Filtro &&
                                    w.Hasta.Date == filtroGantt.FechaPlanificacion.Date)
                        .Select(s =>
                        new GanttModel($"{s.Funcionario.Numero} - {s.Funcionario.Nombres} {s.Funcionario.Apellidos}",
                                          s.Desde, s.Hasta, filtroGantt.FechaPlanificacion.Date)).ToList();
                }
                else
                {
                    dataGanttAusencias = db.Ausencias
                     .Where(w => w.Computo.NombreDescriptivo == filtroGantt.Filtro)
                     .Select(s =>
                      new GanttModel($"{s.Funcionario.Numero} - {s.Funcionario.Nombres} {s.Funcionario.Apellidos}",
                                          s.Desde, s.Hasta, filtroGantt.FechaPlanificacion.Date)).ToList();
                }
                return dataGanttAusencias;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
