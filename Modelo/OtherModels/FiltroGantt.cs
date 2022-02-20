using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.OtherModels
{
    public class FiltroGantt
    {
        public string Filtro { get; set; }
        public bool FechaLimite { get; set; }

        public DateTime FechaPlanificacion { get; set; }
    }
}
