using Modelo;
using Modelo.OtherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IRepositorios
{
    public interface IRepoServicio
    {
        public Task<List<ServicioDTO>> ObtenerTodosActivosSegunMesaOperativa(GeneralTransport modelo);
        public Task<List<ServicioDTO>> ObtenerTodosActivos();
        public Task<List<ServicioDTO>> ObtenerPorCliente(int clienteId);
        public Task<ServicioDTO> Agregar(ServicioDTO modelo);
        public Task<ServicioDTO> Actualizar(ServicioDTO modelo);
        public Task<bool> DarBaja(int id);
        public Task<bool> DarBajaServicios(int clienteId);
        public Task<ServicioDTO> ObtenerPrimerServicio();
    }
}
