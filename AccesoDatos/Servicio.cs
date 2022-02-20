using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Servicio
    {
        public int Id { get; set; }
        public string NombreDescriptivo { get; set; }
        public Cliente Cliente { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string Geolocalizacion { get; set; }
        public string Direccion { get; set; }
        public string NombreCoordinacion { get; set; }
        public string TelCoordinacion { get; set; }
        public string NombreContactoServicio { get; set; }
        public string TelContactoServicio { get; set; }
        public string Estado { get; set; }
        public string Detalle { get; set; }
        public MesaOperativa DependeDe { get; set; }
        public bool Activo { get; set; }
        public bool GuardiaFisica { get; set; }
    }
}
