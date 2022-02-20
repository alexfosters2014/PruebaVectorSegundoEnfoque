using Modelo;
using Modelo.OtherModels;
using Modelo.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VectorCliente.Services.IServices;

namespace VectorCliente.Services
{
    public class ServiceDataEscalafon : IServiceDataEscalafon
    {
        private readonly HttpClient httpClient;


        public ServiceDataEscalafon(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public async Task<EscalafonModel> CrearNuevo(GeneralTransport modelo, string token)
        {
            if (modelo == null)
            {
                throw new Exception("No existe datos a buscar");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Escalafon/NuevoEscalafon/", modelo);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var EscalafonModel = JsonConvert.DeserializeObject<EscalafonModel>(content);
                return EscalafonModel;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }
        public async Task<EscalafonModel> AbrirPlanificacion(GeneralTransport modelo, string token)
        {
            if (modelo == null)
            {
                throw new Exception("No existe datos a buscar");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Escalafon/AbrirEscalafon/", modelo);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var EscalafonModel = JsonConvert.DeserializeObject<EscalafonModel>(content);
                return EscalafonModel;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }
        public async Task<EscalafonModel> CopiaEscalafon(GeneralTransport modelo, string token)
        {
            if (modelo == null)
            {
                throw new Exception("No existe datos a buscar");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Escalafon/CopiarEscalafon/", modelo);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var EscalafonModel = JsonConvert.DeserializeObject<EscalafonModel>(content);
                return EscalafonModel;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }
        public async Task<PlanificacionDiariaDTO> ActualizarPlanDiario(PlanificacionDiariaDTO modelo, string token)
        {
            if (modelo == null)
            {
                throw new Exception("No existe datos a buscar");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Escalafon/ActualizarPlanDiario/", modelo);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<PlanificacionDiariaDTO>(content);
                return resultado;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<bool> ExisteFechaEscalafon(GeneralTransport modelo, string token)
        {
            if (modelo == null)
            {
                throw new Exception("No existe datos a buscar");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Escalafon/ExisteFechaEscalafon/", modelo);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<bool>(content);
                return resultado;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<PlanificacionDiariaDTO> AgregarNuevoPlanDiario(PlanificacionDiariaDTO modelo, string token)
        {
            if (modelo == null)
            {
                throw new Exception("No existe datos a buscar");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync("/api/Escalafon/AgregarPlanDiario", modelo);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<PlanificacionDiariaDTO>(content);
                return resultado;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<PlanificacionDiariaDTO> AgregarFuncionarioEnBolsa(FuncionarioFecha modelo, string token)
        {
            if (modelo == null)
            {
                throw new Exception("No existe datos a buscar");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync("/api/Escalafon/AgregarFuncionarioEstadoBolsa", modelo);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<PlanificacionDiariaDTO>(content);
                return resultado;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }//**

        public async Task<NombrePuestoDTO> AgregarNombrePuesto(NombrePuestoDTO modelo, string token)
        {

            if (modelo == null)
            {
                throw new Exception("No existe datos a buscar");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Escalafon/AgregarNombrePuesto/", modelo);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<NombrePuestoDTO>(content);
                return resultado;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<List<NombrePuestoDTO>> ObtenerNombrePuestos(GeneralTransport modelo, string token)
        {
            if (modelo == null)
            {
                throw new Exception("No existe datos a buscar");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Escalafon/ObtenerNombresPuestos/", modelo);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<NombrePuestoDTO>>(content);
                return resultado;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<PlanificacionDiariaDTO> EliminarEstado(PlanificacionDiariaDTO modelo, string token)
        {
            if (modelo == null)
            {
                throw new Exception("No existe estado a eliminar");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Escalafon/EliminarEstado/", modelo);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<PlanificacionDiariaDTO>(content);
                return resultado;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<bool> ImportarClientesYServicios(ClientesServiciosImport modelo, string token)
        {
            if (modelo == null)
            {
                throw new Exception("No existe datos a buscar");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Escalafon/ImportarCliServ/", modelo);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<bool>(content);
                return resultado;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<List<PlanificacionDiariaDTO>> ActualizarPlanesDiariosSegundoNivel(List<PlanificacionDiariaDTO> estados, string token)
        {
            if (estados == null)
            {
                throw new Exception("No existe datos a buscar");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Escalafon/ActualizarPlanesDiariosSegundoNivel/", estados);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<PlanificacionDiariaDTO>>(content);
                return resultado;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }
        public async Task<List<PlanificacionDiariaDTO>> ObtenerPlanificacionServicio(VisorHistorialServicio modelo, string token)
        {
            if (modelo == null)
            {
                throw new Exception("No existe datos a buscar");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Escalafon/ObtenerPlanificacionPorServicio/", modelo);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<PlanificacionDiariaDTO>>(content);
                return resultado;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<List<GanttModel>> ObtenerGanttAusencias(FiltroGantt modelo, string token)
        {
            if (modelo == null)
            {
                throw new Exception("No existe datos a buscar");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Escalafon/AusenciasGantt/", modelo);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var ganttAsuencias = JsonConvert.DeserializeObject<List<GanttModel>>(content);
                return ganttAsuencias;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }


    }
}
