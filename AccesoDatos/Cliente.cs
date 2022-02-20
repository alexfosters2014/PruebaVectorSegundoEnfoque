using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string RutCi { get; set; }
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Observacion { get; set; }
        public bool Activo { get; set; }
    }
}
