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
    public class RepoMesaOperativa : IRepoMesaOperativa
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public RepoMesaOperativa(AppDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        public async Task<MesaOperativaDTO> Actualizar(MesaOperativaDTO modelo)
        {
            try
            {
                MesaOperativa mopDB = await db.MesasOperativas.SingleAsync(s => s.Id == modelo.Id);
                MesaOperativa mop = mapper.Map<MesaOperativaDTO, MesaOperativa>(modelo, mopDB);
                var update = db.MesasOperativas.Update(mop);
                await db.SaveChangesAsync();
                return mapper.Map<MesaOperativa, MesaOperativaDTO>(update.Entity);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<MesaOperativaDTO> Agregar(MesaOperativaDTO modelo)
        {
            try
            {
                MesaOperativa duplicado = await db.MesasOperativas.FirstOrDefaultAsync(f => f.Nombre == modelo.Nombre);
                if (duplicado != null)
                {
                    return null;
                }
                MesaOperativa mop = mapper.Map<MesaOperativaDTO, MesaOperativa>(modelo);
                var add = await db.MesasOperativas.AddAsync(mop);
                await db.SaveChangesAsync();
                MesaOperativaDTO uFinal = mapper.Map<MesaOperativa, MesaOperativaDTO>(add.Entity);
                return uFinal;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<MesaOperativaDTO>> Obtener()
        {
            List<MesaOperativaDTO> mesasOp = mapper.Map<List<MesaOperativa>, List<MesaOperativaDTO>>(db.MesasOperativas.ToList());
            return mesasOp;
        }
    }
}
