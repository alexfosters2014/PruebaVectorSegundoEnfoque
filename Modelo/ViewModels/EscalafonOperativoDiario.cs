using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ViewModels
{
    public class EscalafonOperativoDiario
    {
        public List<ServicioDTO> ServiciosDTO { get; set; }
        public List<AusenciaDTO> AusenciasDTO { get; set; }
        public List<OperativaDiariaDTO> planesDiarios { get; set; }
        public List<ClienteDTO> ClientesDTO { get; set; }
        public List<ComputoDTO> ComputosDTO { get; set; }
        public List<FuncionarioDTO> funcionariosDTO { get; set; }
    }
}
