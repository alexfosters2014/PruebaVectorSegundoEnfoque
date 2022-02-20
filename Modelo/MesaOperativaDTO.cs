using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class MesaOperativaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="No puede estar vacio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        public string Descripcion { get; set; }
    }
}
