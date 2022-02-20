using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PlanificacionDiaria
    {
        public int Id { get; set; }
        public string Orden { get; set; }
        public DateTime Fecha { get; set; }
        public Funcionario FuncionarioOperativo { get; set; }
        public string NombrePuesto { get; set; }
        public string TipoPuesto { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public Servicio Servicio { get; set; }
        public DateTime HoraEntradaMarcada { get; set; }
        public DateTime HoraSalidaMarcada { get; set; }
        public bool Facturable { get; set; }
        public Computo Computo { get; set; }
        public double CantidadHorasTotales { get; set; }
        public double CantidadHorasExtras { get; set; }
        public double CantidadHorasArmado { get; set; }
        public string Observaciones { get; set; }
        public string FuncionarioSegundoNivel { get; set; } //
        public int Turno { get; set; }
        public bool ComienzoJornada { get; set; }
        public string TipoFuncionarioOperativo { get; set; }
        public bool Extra { get; set; }
        public bool HoySegundoLibre { get; set; }
        public DateTime ProximoSegundoLibre { get; set; }
        public string TipoResumido { get; set; }//FIJO//RETEN//PUNTUAL
        public bool MostrarEnEscalafon{ get; set; }
        public bool Rotativo { get; set; }
        public bool SegundoNivel { get; set; }
        public bool TengoSegundoNivelActivo { get; set; }
        public int IdMesaOperativa { get; set; }
    }
}
