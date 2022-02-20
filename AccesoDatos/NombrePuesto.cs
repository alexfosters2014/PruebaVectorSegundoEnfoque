using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class NombrePuesto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Servicio Servicio { get; set; }
    }
}
