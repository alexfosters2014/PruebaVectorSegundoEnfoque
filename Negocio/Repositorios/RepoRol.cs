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
    public class RepoRol : IRepoRol
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public RepoRol(AppDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        public async Task<RolDTO> Agregar(RolDTO modelo)
        {
            try
            {
                    Rol rol = mapper.Map<RolDTO, Rol>(modelo);
                    var add = await db.Roles.AddAsync(rol);
                    await db.SaveChangesAsync();
                    RolDTO uFinal = mapper.Map<Rol, RolDTO>(add.Entity);
                    return uFinal;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<RolDTO> Actualizar(RolDTO modelo)
        {
            try
            {
                    Rol rolDB = await db.Roles.SingleAsync(s => s.Id == modelo.Id);
                    Rol rol = mapper.Map<RolDTO, Rol>(modelo, rolDB);
                    var update = db.Roles.Update(rol);
                    await db.SaveChangesAsync();
                    return mapper.Map<Rol, RolDTO>(update.Entity);
             }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<RolDTO>> Obtener()
        {
            List<RolDTO> roles = mapper.Map<List<Rol>, List<RolDTO>>(db.Roles.ToList());
            return roles;
        }
    }
}
