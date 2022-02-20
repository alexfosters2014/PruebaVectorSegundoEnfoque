using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.OtherModels
{
    public class FuncionarioDTOSinValid
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdTipoContrato { get; set; }
        public TipoContratoDTO TipoContrato { get; set; } = null;
        public double SueldoNominal { get; set; }
        public int IdRespondeA { get; set; }
        public MesaOperativaDTO RespondeA { get; set; }
        public string Observaciones { get; set; }
        public string EstadoActividad { get; set; }
        public string DepartamentoOperativo { get; set; }
        public int IdRubro { get; set; }
        public RubroDTO Rubro { get; set; }
        public string UltimaActualizacion { get; set; }
    }
}
