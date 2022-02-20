using Modelo.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class FuncionarioDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        [Range(1,int.MaxValue,ErrorMessage ="No puede tener valor cero")]
        public int Numero { get; set; }
        [CedulaVerification]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        [MaxLength(60,ErrorMessage ="Puede introducir hasta 60 caracteres")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        [MaxLength(60, ErrorMessage = "Puede introducir hasta 60 caracteres")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Today;
        public string Telefono { get; set; }
        public string Celular { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        public string Direccion { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage ="La fecha es obligatoria")]
        public DateTime FechaIngreso { get; set; } = DateTime.Today;
        public DateTime? FechaEgreso { get; set; } 
        public TipoContratoDTO TipoContrato { get; set; }
        public DateTime VtoCarneSalud { get; set; } = DateTime.Today;
        public DateTime FechaEmisionCAJ { get; set; } = DateTime.Today;
        public double SueldoNominal { get; set; }
        public MesaOperativaDTO RespondeA { get; set; }
        public string Observaciones { get; set; }
        public string EstadoActividad { get; set; }
        public bool Reingreso { get; set; }
        public DateTime? UltimaFechadeBaja { get; set; }
        public bool habArmado { get; set; }
        public string Zona { get; set; }
        public string DepartamentoOperativo { get; set; }
        public RubroDTO Rubro { get; set; }
        public string UltimaActualizacion { get; set; }
        public string TipoResumido { get; set; } //reten,puntual,Fijo
        public bool Rotativo { get; set; }
        public bool SegundoLibreTrabajado { get; set; }
        public bool SegundoLibrePosterior { get; set; }
        public int DiaLibre { get; set; } = 0;

        public string NombreCorto()
        {
            string[] nombres = Nombres.Split(" ");
            return $"{nombres[0]} {Apellidos}";
        }
        public string NumeroSegundoNivel()
        {
            return NumeroNombres();
        }
        public string NumeroNombres()
        {
            return $"{Numero}-{NombreCorto()}";
        }

        public override string ToString()
        {
            return Nombres + " " + Apellidos;
        }
    }
}
