using Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VectorCliente.Services.IServices
{
    public interface IServicePrefFunServicio
    {
        public Task<PreferenciaFuncionarioServicioDTO> Agregar(PreferenciaFuncionarioServicioDTO preferenciaDTO, string token);
        public Task<bool> Eliminar(int idPref, string token);
        public Task<bool> GuardarCambios(List<PreferenciaFuncionarioServicioDTO> preferenciasDTO, string token);
        public Task<List<PreferenciaFuncionarioServicioDTO>> Obtener(int idServicio, string token);
    }
}
