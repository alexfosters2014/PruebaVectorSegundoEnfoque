using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    //[Index(nameof(Nombre), IsUnique = true)]
    public class Rubro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [MaxLength(5)]
        public string Grupo { get; set; }
        [MaxLength(5)]
        public string SubGrupo { get; set; }
    }
}
