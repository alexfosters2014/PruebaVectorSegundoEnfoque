using Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.OtherModels
{
    public class FuncionarioImport
    {
        public int Numero { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; } = DateTime.Today;
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public TipoContratoImport TipoContrato { get; set; }
        public double SueldoNominal { get; set; }
        public MesaOpImport RespondeA { get; set; }
        public string Observaciones { get; set; }
        public string EstadoActividad { get; set; } = SD.EstadoFuncionarioEnum.ACTIVO.ToString();
        public string DepartamentoOperativo { get; set; }
        public RubroImport Rubro { get; set; }
        public string UltimaActualizacion { get; set; } = DateTime.Now.ToString();
        public string TipoResumido { get; set; } //reten,puntual,Fijo
    }
}
