using Modelo;
using Modelo.ViewModels;
using Modelo.OtherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VectorCliente.Services.IServices
{
    public interface IServiceMesaOperativa
    {
        public Task<MesaOperativaDTO> Agregar(MesaOperativaDTO mesaOperativaDTO, string token);

        public Task<MesaOperativaDTO> Actualizar(MesaOperativaDTO mesaOperativaDTO, string token);
        //public Task<MesaOperativaDTO> Obtener(int usuarioId, string token);
        public Task<List<MesaOperativaDTO>> ObtenerTodos(string token);
        public Task<bool> Eliminar(int Id, string token);
    }
}
