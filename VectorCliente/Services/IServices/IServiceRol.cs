using Modelo;
using Modelo.ViewModels;
using Modelo.OtherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VectorCliente.Services.IServices
{
    public interface IServiceRol
    {
        public Task<RolDTO> Agregar(RolDTO RolDTO, string token);

        public Task<RolDTO> Actualizar(RolDTO RolDTO, string token);
        //public Task<RolDTO> Obtener(int usuarioId, string token);
        public Task<List<RolDTO>> ObtenerTodos(string token);
        public Task<bool> Eliminar(int Id, string token);
    }
}
