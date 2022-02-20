using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ViewModels
{
    public class TurnosPuestosOperativos
    {
        public int Turno { get; set; }
        public List<OperativaDiariaDTO> PlanesDTO { get; set; }
    }
}
