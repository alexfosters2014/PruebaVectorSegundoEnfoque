using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ViewModels
{
    public class TurnoPuestos
    {
        public int Turno { get; set; }
        public List<PlanificacionDiariaDTO> PlanesDTO { get; set; }
    }
}
