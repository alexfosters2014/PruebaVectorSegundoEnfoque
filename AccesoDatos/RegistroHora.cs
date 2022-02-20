using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class RegistroHora
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Funcionario Funcionario { get; set; }
        public Servicio Servicio { get; set; }
        public string NombrePuesto { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public Computo Computo { get; set; }
        public double Falta { get; set; }
        public double CantidadHorasDiurnas { get; set; }
        public double CantidadHorasNocturnas { get; set; }
        public double CantidadHorasEfectivas { get; set; }
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
