using Modelo;
using Modelo.OtherModels;
using Modelo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VectorCliente.Services.IServices
{
    public interface IServiceDataEscalafon
    {
        public Task<EscalafonModel> CrearNuevo(GeneralTransport modelo, string token);
        public Task<EscalafonModel> AbrirPlanificacion(GeneralTransport modelo, string token);
        public Task<EscalafonModel> CopiaEscalafon(GeneralTransport modelo, string token);
        public Task<bool> ExisteFechaEscalafon(GeneralTransport modelo, string token);
        public Task<PlanificacionDiariaDTO> AgregarNuevoPlanDiario(PlanificacionDiariaDTO modelo, string token);
        public Task<PlanificacionDiariaDTO> AgregarFuncionarioEnBolsa(FuncionarioFecha modelo, string token);
        public Task<PlanificacionDiariaDTO> ActualizarPlanDiario(PlanificacionDiariaDTO modelo, string token);
        public Task<NombrePuestoDTO> AgregarNombrePuesto(NombrePuestoDTO modelo, string token);
        public Task<List<NombrePuestoDTO>> ObtenerNombrePuestos(GeneralTransport modelo, string token);
        public Task<PlanificacionDiariaDTO> EliminarEstado(PlanificacionDiariaDTO modelo, string token);
        public Task<bool> ImportarClientesYServicios(ClientesServiciosImport modelo, string token);
        public Task<List<PlanificacionDiariaDTO>> ActualizarPlanesDiariosSegundoNivel(List<PlanificacionDiariaDTO> estados, string token);
        public Task<List<PlanificacionDiariaDTO>> ObtenerPlanificacionServicio(VisorHistorialServicio modelo, string token);
        public Task<List<GanttModel>> ObtenerGanttAusencias(FiltroGantt modelo, string token);
    }
}
