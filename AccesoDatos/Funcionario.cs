using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Funcionario
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
        public DateTime? FechaEgreso { get; set; }
        public TipoContrato TipoContrato { get; set; }
        public DateTime VtoCarneSalud { get; set; }
        public DateTime FechaEmisionCAJ { get; set; }
        public double SueldoNominal { get; set; }
        public MesaOperativa RespondeA { get; set; }
        public string Observaciones { get; set; }
        public string EstadoActividad { get; set; }
        public bool Reingreso { get; set; }
        public DateTime? UltimaFechadeBaja { get; set; }
        public bool habArmado { get; set; }
        public string Zona { get; set; }
        public string DepartamentoOperativo { get; set; }
        public Rubro Rubro { get; set; }
        public string UltimaActualizacion { get; set; }
        public string TipoResumido { get; set; } //reten,puntual,Fijo
        public bool Rotativo { get; set; }
        public bool SegundoLibreTrabajado { get; set; }
        public bool SegundoLibrePosterior { get; set; }
        public int DiaLibre { get; set; }

    }
}
