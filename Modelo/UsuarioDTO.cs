using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="No puede estar vacio")]
        public string NombreUsuario { get; set; }
        public RolDTO Rol { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        public string Email { get; set; }
        public bool Activo { get; set; }
        public MesaOperativaDTO MesaOperativa { get; set; }
        public string Token { get; set; }
        public string  PassInicial { get; set; }
    }
}
