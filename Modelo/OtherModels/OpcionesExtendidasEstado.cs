using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.OtherModels
{
    public class OpcionesExtendidasEstado
    {
        public bool ComienzoJornada { get; set; }
        public bool Extra { get; set; }
        public bool Facturable { get; set; }
        public DateTime ProximoSegundoLibre { get; set; }
        public bool HoySegundoLibre { get; set; }
        public double TotalHorasArmado { get; set; }
        public bool CorrespondeAlDiaSiguiente { get; set; }
    }
}
