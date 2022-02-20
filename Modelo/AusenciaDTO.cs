using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class AusenciaDTO
    {
        public int Id { get; set; }
        public FuncionarioDTO Funcionario { get; set; }
        public ComputoDTO Computo { get; set; }
        public ServicioDTO Servicio { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public string Observaciones { get; set; }
        public bool ConfirmadoPorRRHH { get; set; }
    }
}
