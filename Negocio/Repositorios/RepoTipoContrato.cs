using AccesoDatos;
using AutoMapper;
using Modelo;
using Negocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorios
{
    public class RepoTipoContrato : IRepoTipoContrato
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;

        public RepoTipoContrato(AppDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        public async Task<TipoContratoDTO> Agregar(TipoContratoDTO modelo)
        {
            try
            {
                TipoContrato contrato = mapper.Map<TipoContratoDTO, TipoContrato>(modelo);
                var add = await db.TiposContratos.AddAsync(contrato);
                await db.SaveChangesAsync();
                TipoContratoDTO uFinal = mapper.Map<TipoContrato, TipoContratoDTO>(add.Entity);
                return uFinal;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<TipoContratoDTO>> Obtener()
        {
            try
            {
                List<TipoContratoDTO> tc =
                    mapper.Map<List<TipoContrato>, List<TipoContratoDTO>>(db.TiposContratos.ToList());
                return tc;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
