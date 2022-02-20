using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public MesaOperativa MesaOperativa { get; set; }
    }
}
