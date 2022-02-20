using AccesoDatos;
using AutoMapper;
using Comun;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.OtherModels;
using Negocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorios
{

    public class RepoServicio : IRepoServicio
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public RepoServicio(AppDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }
        public async Task<ServicioDTO> Actualizar(ServicioDTO modelo)
        {
            try
            {
                Servicio servicioDB = await db.Servicios.SingleAsync(s => s.Id == modelo.Id);
                Servicio servicio = mapper.Map<ServicioDTO, Servicio>(modelo, servicioDB);
                var update = db.Servicios.Update(servicio);
                await db.SaveChangesAsync();
                return mapper.Map<Servicio, ServicioDTO>(update.Entity);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ServicioDTO> Agregar(ServicioDTO modelo)
        {
            try
            {
                Servicio servicio = mapper.Map<ServicioDTO, Servicio>(modelo);

                db.Entry(servicio.Cliente).State = EntityState.Unchanged;
                db.Entry(servicio.DependeDe).State = EntityState.Unchanged;
                var add = await db.Servicios.AddAsync(servicio);
                await db.SaveChangesAsync();
                ServicioDTO uFinal = mapper.Map<Servicio, ServicioDTO>(add.Entity);
                return uFinal;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DarBaja(int id)
        {
            Servicio servicio = await db.Servicios.FindAsync(id);
            servicio.Activo = false;
            db.Servicios.Update(servicio);
            int update = await db.SaveChangesAsync();
            if (update == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DarBajaServicios(int clienteId)
        {
            List<Servicio> servicios = db.Servicios.Include(i => i.Cliente)
                                                   .Include(i => i.DependeDe)
                                                   .Where(w => w.Cliente.Id == clienteId && w.Activo == true).ToList();

            servicios.ForEach(f => f.Activo = false);
            int update = await db.SaveChangesAsync();
            if (update == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<List<ServicioDTO>> ObtenerPorCliente(int clienteId)
        {
            try
            {
                List<ServicioDTO> servicios = mapper.Map<List<Servicio>, List<ServicioDTO>>(
                                                db.Servicios
                                                .Include(i => i.Cliente)
                                                .Include(i => i.DependeDe)
                                                .Where(w => w.Activo == true &&
                                                            w.Cliente.Id == clienteId)
                                                .ToList());

                return servicios;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ServicioDTO> ObtenerPrimerServicio()
        {
            try
            {

                 List<ServicioDTO> servicios = mapper.Map<List<Servicio>, List<ServicioDTO>>(db.Servicios.Take(1).ToList());
                if (servicios != null && servicios.Count > 0)
                {
                    return servicios[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<ServicioDTO>> ObtenerTodosActivos()
        {
            try
            {
                List<ServicioDTO> servicios = mapper.Map<List<Servicio>, List<ServicioDTO>>(
                                                db.Servicios
                                                .Include(i => i.Cliente)
                                                .Include(i => i.DependeDe)
                                                .Where(w => w.Activo == true)
                                                .ToList());

                return servicios;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<ServicioDTO>> ObtenerTodosActivosSegunMesaOperativa(GeneralTransport modelo)
        {
            try
            {
                List<ServicioDTO> servicios = mapper.Map<List<Servicio>, List<ServicioDTO>>(
                                                db.Servicios
                                                .Include(i => i.Cliente)
                                                .Include(i => i.DependeDe)
                                                .Where(w => w.Activo == true && 
                                                            w.DependeDe.Id == modelo.Valor &&
                                                            w.GuardiaFisica == true)
                                                .ToList());

                return servicios;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
