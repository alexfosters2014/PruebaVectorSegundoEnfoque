using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.OtherModels
{
    public class ModelFunContratosMop
    {
        public List<TipoContratoDTO> TiposContratos { get; set; }
        public List<MesaOperativaDTO> MesasOperativas { get; set; }
        public List<RubroDTO> Rubros { get; set; }
    }
}
