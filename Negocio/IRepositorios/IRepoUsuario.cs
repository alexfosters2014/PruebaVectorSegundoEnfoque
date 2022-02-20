using Modelo;
using Modelo.ViewModels;
using Modelo.OtherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IRepositorios
{
    public interface IRepoUsuario
    {
        public Task<UsuarioDTO> Agregar(UsuarioDTO modelo);
        public Task<bool>Eliminar (int Id);
        public Task<UsuarioDTO> Modificar(UsuarioDTO modelo);
        public Task<UsuarioDTO> Obtener(int Id);
        public Task<List<UsuarioDTO>> Obtener();
        public Task<UsuarioDTO> Login(VMLogin vmLogin);

    }
}
