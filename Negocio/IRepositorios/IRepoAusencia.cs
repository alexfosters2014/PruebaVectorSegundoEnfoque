using Modelo;
using Modelo.OtherModels;
using Modelo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IRepositorios
{
    public interface IRepoAusencia
    {
        public Task<List<AusenciaDTO>> ObtenerEnFecha(GeneralTransport modelo);
        public Task<AusenciaDTO> Agregar(AusenciaDTO modelo);
        public Task<List<GanttModel>> ObtenerPeriodoAusenciasVigentes(FiltroGantt filtroGantt);
    }
}
