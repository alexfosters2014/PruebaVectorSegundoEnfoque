using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class NombrePuestoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ServicioDTO Servicio { get; set; }
    }
}
