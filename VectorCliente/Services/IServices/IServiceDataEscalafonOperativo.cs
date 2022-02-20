using Modelo;
using Modelo.OtherModels;
using Modelo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VectorCliente.Services.IServices
{
    public interface IServiceDataEscalafonOperativo
    {
        public Task<EscalafonOperativoDiario> AbrirPlanificacion(GeneralTransport modelo, string token);
        public Task<bool> ExisteFechaEscalafon(GeneralTransport modelo, string token);
        public Task<OperativaDiariaDTO> AgregarNuevoPlanDiario(OperativaDiariaDTO modelo, string token);
        public Task<OperativaDiariaDTO> ActualizarPlanDiario(OperativaDiariaDTO modelo, string token);
        public Task<List<NombrePuestoDTO>> ObtenerNombrePuestos(GeneralTransport modelo, string token);
        public Task<bool> EliminarEstado(int? id, string token);
        public Task<bool> CheckIn(int? id, string token);
        public Task<bool> CheckOut(int? id, string token);
    }
}
