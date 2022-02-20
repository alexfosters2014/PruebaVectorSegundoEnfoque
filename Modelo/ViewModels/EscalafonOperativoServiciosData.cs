using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ViewModels
{
    public class EscalafonOperativoServiciosData
    {
        public ServicioDTO ServicioDTO { get; set; }
        public List<OperativaDiariaDTO> EstadosOperativosDTO { get; set; }
    }
}
