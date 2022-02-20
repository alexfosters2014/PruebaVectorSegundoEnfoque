using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Ausencia
    {
        public int Id { get; set; }
        public Funcionario Funcionario { get; set; }
        public Computo Computo { get; set; }
        public Servicio Servicio { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public string Observaciones { get; set; }
        public bool ConfirmadoPorRRHH { get; set; }

    }
}
