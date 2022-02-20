using AccesoDatos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Negocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorios
{
    public class RepoRepoPreferenciaFuncionarioServicio : IRepoPreferenciaFuncionarioServicio
    {

        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public RepoRepoPreferenciaFuncionarioServicio(AppDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }
        public async Task<PreferenciaFuncionarioServicioDTO> Agregar(PreferenciaFuncionarioServicioDTO preferencia)
        {
            try
            {
                PreferenciaFuncionarioServicio pref = mapper.Map<PreferenciaFuncionarioServicioDTO, PreferenciaFuncionarioServicio>(preferencia);

                db.Entry(pref.Servicio).State = EntityState.Unchanged;
                db.Entry(pref.Funcionario).State = EntityState.Unchanged;
                var add = await db.PreferenciasFuncionariosServicio.AddAsync(pref);
                await db.SaveChangesAsync();
                PreferenciaFuncionarioServicioDTO uFinal = mapper.Map<PreferenciaFuncionarioServicio, PreferenciaFuncionarioServicioDTO>(add.Entity);
                return uFinal;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> Eliminar(int IdPref)
        {
            try
            {
                PreferenciaFuncionarioServicio pref = await db.PreferenciasFuncionariosServicio.FindAsync(IdPref);
                db.PreferenciasFuncionariosServicio.Remove(pref);
                int eliminar = await db.SaveChangesAsync();
                if (eliminar == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> GuardarCambios(List<PreferenciaFuncionarioServicioDTO> preferencias)
        {
            try
            {
                List<PreferenciaFuncionarioServicio> prefs = mapper.Map<List<PreferenciaFuncionarioServicioDTO>, List<PreferenciaFuncionarioServicio>>(preferencias);

                Servicio servicio = await db.Servicios.FindAsync(prefs[0].Servicio.Id);

                foreach (var pref in prefs)
                {
                    pref.Servicio = servicio;
                    db.Entry(pref.Servicio).State = EntityState.Unchanged;
                    db.Entry(pref.Funcionario).State = EntityState.Unchanged;
                }
                db.PreferenciasFuncionariosServicio.UpdateRange(prefs);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<PreferenciaFuncionarioServicioDTO>> ObtenerTodos(int idServicio)
        {
            try
            {
                List<PreferenciaFuncionarioServicioDTO> prefs = mapper.Map<List<PreferenciaFuncionarioServicio>, List<PreferenciaFuncionarioServicioDTO>>(
                                               db.PreferenciasFuncionariosServicio
                                               .Include(i => i.Funcionario)
                                               .Include(i => i.Servicio)
                                               .Where(w => w.Servicio.Id == idServicio)
                                               .ToList());

                return prefs;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
