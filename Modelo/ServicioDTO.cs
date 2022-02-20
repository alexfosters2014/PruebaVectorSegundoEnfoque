using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ServicioDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        public string NombreDescriptivo { get; set; }
        public ClienteDTO Cliente { get; set; }
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        public string Departamento { get; set; }
        public string Geolocalizacion { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        public string Direccion { get; set; }
        public string NombreCoordinacion { get; set; }
        public string TelCoordinacion { get; set; }
        public string NombreContactoServicio { get; set; }
        public string TelContactoServicio { get; set; }
        public string Estado { get; set; }
        public string Detalle { get; set; }
        public MesaOperativaDTO DependeDe { get; set; }
        public bool Activo { get; set; }
        public bool GuardiaFisica { get; set; }
    }
}
