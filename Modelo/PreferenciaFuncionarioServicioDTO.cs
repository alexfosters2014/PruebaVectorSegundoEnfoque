using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class PreferenciaFuncionarioServicioDTO
    {
        public int Id { get; set; }
        public FuncionarioDTO Funcionario { get; set; }
        public ServicioDTO Servicio { get; set; }
        public string Observaciones { get; set; }
    }
}
