using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VectorCliente.Services.IServices
{
    public interface IServiceCliente
    {
        public Task<ClienteDTO> Agregar(ClienteDTO clienteDTO, string token);
        public Task<ClienteDTO> Actualizar(ClienteDTO clienteDTO, string token);
        //public Task<ClienteDTO> Obtener(int Id, string token);
        public Task<List<ClienteDTO>> ObtenerTodos(string token);
        public Task<bool> Baja(int clienteId, string token);
    }
}
