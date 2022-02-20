using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IRepositorios
{
    public interface IRepoMesaOperativa
    {
        public Task<List<MesaOperativaDTO>> Obtener();
        public Task<MesaOperativaDTO> Actualizar(MesaOperativaDTO modelo);
        public Task<MesaOperativaDTO> Agregar(MesaOperativaDTO modelo);
    }
}
