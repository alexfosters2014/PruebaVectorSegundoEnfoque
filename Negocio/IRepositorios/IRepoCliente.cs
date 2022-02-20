using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IRepositorios
{
    public interface IRepoCliente
    {
        public Task<List<ClienteDTO>> ObtenerTodosActivos();
        public Task<ClienteDTO> Agregar(ClienteDTO modelo);
        public Task<ClienteDTO> Actualizar(ClienteDTO modelo);
        public Task<bool> DarBaja(int id);
    }
}
