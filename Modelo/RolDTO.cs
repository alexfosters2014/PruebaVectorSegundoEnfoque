using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RolDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        public string RolAsignado { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        public int Nivel { get; set; }
    }
}
