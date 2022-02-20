using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RegistroHoraDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public FuncionarioDTO Funcionario { get; set; }
        public ServicioDTO Servicio { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public ComputoDTO Computo { get; set; }
        public double Falta { get; set; }
        public double CantidadHorasDiurnas { get; set; }
        public double CantidadHorasNocturnas { get; set; }
        public double CantidadHorasExtras { get; set; }
        public double CantidadHorasArmado { get; set; }
        public double CantidadHrsExtrasLibreTrabajado { get; set; }
        public double CantidadHorasNocLibreTrabajado { get; set; }
        public string Observaciones { get; set; }
        public bool Facturable { get; set; }
        public bool ComienzoJornada { get; set; }
        public bool EnlaceHorario { get; set; }
    }
}
