using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IRepositorios
{
    public interface IRepoRubro
    {
        public Task<List<RubroDTO>> Obtener();
        public Task<RubroDTO> Agregar(RubroDTO modelo);
    }
}
