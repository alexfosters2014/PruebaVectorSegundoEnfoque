using Modelo;
using Modelo.OtherModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VectorCliente.Services.IServices;

namespace VectorCliente.Services
{
    public class ServicePrefFunServicio : IServicePrefFunServicio
    {
        private readonly HttpClient httpClient;
        public ServicePrefFunServicio(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }
        public async Task<PreferenciaFuncionarioServicioDTO> Agregar(PreferenciaFuncionarioServicioDTO preferenciaDTO, string token)
        {
            if (preferenciaDTO == null) throw new Exception("No existe el modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/PreferenciasFuncionariosEnServicio", preferenciaDTO);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var pr = JsonConvert.DeserializeObject<PreferenciaFuncionarioServicioDTO>(content);
                return pr;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<bool> Eliminar(int idPref, string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.DeleteAsync($"/api/PreferenciasFuncionariosEnServicio/{idPref}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var pr = JsonConvert.DeserializeObject<bool>(content);
                return pr;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<bool> GuardarCambios(List<PreferenciaFuncionarioServicioDTO> preferenciasDTO, string token)
        {
            if (preferenciasDTO == null) throw new Exception("No existe el modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/PreferenciasFuncionariosEnServicio/GuardarCambios", preferenciasDTO);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var pr = JsonConvert.DeserializeObject<bool>(content);
                return pr;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<List<PreferenciaFuncionarioServicioDTO>> Obtener(int idServicio, string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync($"/api/PreferenciasFuncionariosEnServicio/{idServicio}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var pr = JsonConvert.DeserializeObject<List<PreferenciaFuncionarioServicioDTO>>(content);
                return pr;
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
