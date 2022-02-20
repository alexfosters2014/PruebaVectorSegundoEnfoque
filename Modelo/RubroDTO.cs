using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RubroDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Grupo { get; set; }
        public string SubGrupo { get; set; }

        public static bool Validar(RubroDTO rubro)
        {
            return (!string.IsNullOrEmpty(rubro.Nombre) &&
                    !string.IsNullOrEmpty(rubro.Grupo) &&
                    !string.IsNullOrEmpty(rubro.SubGrupo));
        }
    }
}
