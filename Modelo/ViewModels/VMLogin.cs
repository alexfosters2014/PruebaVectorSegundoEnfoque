using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ViewModels
{
    public class VMLogin
    {
        [Required(ErrorMessage = "Debe ingresar un usuario")]
        public string Usuario { get; set; } = "alexis";
        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        public string Password { get; set; }
    }
}
