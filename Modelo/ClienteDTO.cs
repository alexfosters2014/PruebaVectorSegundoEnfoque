using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se admite formato de numerico")]
        [Required(ErrorMessage = "No puede estar vacio")]
        public string RutCi { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        public string RazonSocial { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        public string NombreFantasia { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Observacion { get; set; }
        public bool Activo { get; set; }
    }
}
