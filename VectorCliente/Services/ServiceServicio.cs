using Modelo;
using Modelo.OtherModels;
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
    public class ServiceServicio : IServiceServicio
    {
        private readonly HttpClient httpClient;
        public ServiceServicio(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }
        public async Task<ServicioDTO> Actualizar(ServicioDTO servicioDTO, string token)
        {
            if (servicioDTO == null) throw new Exception("No existe el modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Servicio/Actualizar", servicioDTO);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var servicio = JsonConvert.DeserializeObject<ServicioDTO>(content);
                return servicio;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<ServicioDTO> Agregar(ServicioDTO servicioDTO, string token)
        {
            if (servicioDTO == null) throw new Exception("No existe el modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Servicio", servicioDTO);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var servicio = JsonConvert.DeserializeObject<ServicioDTO>(content);
                return servicio;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<bool> Baja(int servicioId, string token)
        {
            if (servicioId < 1) throw new Exception("No existe el usuario");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.DeleteAsync($"/api/Servicio/{servicioId}");

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

        public async Task<bool> BajaServiciosPorCliente(int clienteId, string token)
        {
            if (clienteId < 1) throw new Exception("No existe el cliente");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.DeleteAsync($"/api/Servicio/BajaPorCliente/{clienteId}");

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

        public async Task<List<ServicioDTO>> ObtenerPorCliente(int clienteId, string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("No existe usuario");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync($"/api/Servicio/ObtenerPorCliente/{clienteId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var servicios = JsonConvert.DeserializeObject<List<ServicioDTO>>(content);
                return servicios;
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
