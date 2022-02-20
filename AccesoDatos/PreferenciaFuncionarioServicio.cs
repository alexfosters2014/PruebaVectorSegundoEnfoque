using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PreferenciaFuncionarioServicio
    {
        public int Id { get; set; }
        public Funcionario Funcionario { get; set; }
        public Servicio Servicio { get; set; }
        public string Observaciones { get; set; }
    }
}
