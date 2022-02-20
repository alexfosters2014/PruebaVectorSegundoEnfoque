using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VectorCliente.Services.IServices
{
    public interface IServiceServicio
    {
        public Task<ServicioDTO> Agregar(ServicioDTO servicioDTO, string token);
        public Task<ServicioDTO> Actualizar(ServicioDTO servicioDTO, string token);
        public Task<bool> BajaServiciosPorCliente(int clienteId, string token);
        //public Task<List<ServicioDTO>> ObtenerTodos(string token);
        public Task<List<ServicioDTO>> ObtenerPorCliente(int clienteId, string token);
        public Task<bool> Baja(int servicioId, string token);
    }
}
