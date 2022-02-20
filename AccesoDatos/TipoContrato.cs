using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class TipoContrato
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Tipo { get; set; }
        public double CargaTrabajoDiaria{ get; set; }
        public double CargaTrabajoSemanal { get; set; }
        public string Modalidad { get; set; }
    }
}
