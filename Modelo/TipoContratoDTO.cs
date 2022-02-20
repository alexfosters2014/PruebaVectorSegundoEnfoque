using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class TipoContratoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        public string Descripcion { get; set; }
        public int Tipo { get; set; }
        [Range(1, 12, ErrorMessage = "Valor entre 1 y 12")]
        public double CargaTrabajoDiaria { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        public double CargaTrabajoSemanal { get; set; }
        [Required(ErrorMessage = "No puede estar vacio")]
        public string Modalidad { get; set; }
    }
}
