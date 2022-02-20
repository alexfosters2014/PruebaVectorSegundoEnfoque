using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.OtherModels
{
    public class ModelUsuariosRolesMOP
    {
       public List<UsuarioDTO> usuariosDTO { get; set; }
       public List<RolDTO> rolesDTO { get; set; }
       public List<MesaOperativaDTO> mesasOpDTO { get; set; }
    }
}
