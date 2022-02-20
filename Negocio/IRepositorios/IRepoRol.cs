using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IRepositorios
{
    public interface IRepoRol
    {
        public Task<List<RolDTO>> Obtener();
        public Task<RolDTO> Actualizar(RolDTO modelo);
        public Task<RolDTO> Agregar(RolDTO modelo);
    }
}
