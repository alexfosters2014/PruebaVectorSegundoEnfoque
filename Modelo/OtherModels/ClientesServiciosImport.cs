using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.OtherModels
{
    public class ClientesServiciosImport
    {
        public List<ClienteDTO> ClientesDTO { get; set; }
        public List<ServicioImport> ServiciosImport { get; set; }

        public ClientesServiciosImport()
        {
            ClientesDTO = new();
            ServiciosImport = new();
        }
    }
}
