using Modelo;
using Modelo.ViewModels;
using Modelo.OtherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VectorCliente.Services.IServices
{
    public interface IServiceUsuario
    {
        public Task<UsuarioDTO> Agregar(UsuarioDTO usuarioDTO, string token);
        //public Task<UsuarioDTO> Obtener(int usuarioId, string token);
        public Task<List<UsuarioDTO>> ObtenerTodos(string token);
        public Task<bool> Eliminar(int usuarioId, string token);
        public Task<UsuarioDTO> Login(VMLogin vmLogin);
        public Task<ModelUsuariosRolesMOP> ObtenerModelUsuarioRolesMOp(string token);
    }
}
