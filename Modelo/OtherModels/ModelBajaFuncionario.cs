using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.OtherModels
{
    public class ModelBajaFuncionario
    {
        public int Id { get; set; }
        public DateTime FechaBaja { get; set; }
        public string Motivo { get; set; }
        public string Funcionario { get; set; }
    }
}
