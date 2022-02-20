using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.OtherModels
{
    public class ResPlan
    {
        public PlanificacionDiariaDTO Fijo { get; set; } = null;
        public PlanificacionDiariaDTO Rotativo { get; set; } = null;
        public AusenciaDTO Ausencia { get; set; } = null;
        public bool EliminarFijo { get; set; } = false;
        public bool EliminarRotativo { get; set; } = false;
    }
}
