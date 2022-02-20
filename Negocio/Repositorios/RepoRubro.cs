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
    public class RepoRubro : IRepoRubro
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public RepoRubro(AppDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        public async Task<RubroDTO> Agregar(RubroDTO modelo)
        {
            try
            {
                Rubro duplicado = await db.Rubros.FirstOrDefaultAsync(f => f.Nombre == modelo.Nombre);
                if (duplicado != null)
                {
                    return null;
                }
                Rubro rubro = mapper.Map<RubroDTO, Rubro>(modelo);
                var add = await db.Rubros.AddAsync(rubro);
                await db.SaveChangesAsync();
                RubroDTO uFinal = mapper.Map<Rubro, RubroDTO>(add.Entity);
                return uFinal;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<RubroDTO>> Obtener()
        {
            try
            {
                List<RubroDTO> rubros =
                    mapper.Map<List<Rubro>, List<RubroDTO>>(db.Rubros.ToList());
                return rubros;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
