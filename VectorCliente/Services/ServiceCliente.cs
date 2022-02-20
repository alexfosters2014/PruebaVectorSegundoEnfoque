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
    public class ServiceCliente : IServiceCliente
    {
        private readonly HttpClient httpClient;
        public ServiceCliente(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }
        public async Task<ClienteDTO> Actualizar(ClienteDTO clienteDTO, string token)
        {
            if (clienteDTO == null) throw new Exception("No existe el modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Cliente/Actualizar", clienteDTO);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var cliente = JsonConvert.DeserializeObject<ClienteDTO>(content);
                return cliente;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<ClienteDTO> Agregar(ClienteDTO clienteDTO, string token)
        {
            if (clienteDTO == null) throw new Exception("No existe el modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Cliente/", clienteDTO);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var cliente = JsonConvert.DeserializeObject<ClienteDTO>(content);
                return cliente;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<bool> Baja(int clienteId, string token)
        {
            if (clienteId < 1) throw new Exception("No existe el usuario");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.DeleteAsync($"/api/Cliente/{clienteId}");

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

        public async Task<List<ClienteDTO>> ObtenerTodos(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("No existe usuario");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync($"/api/Cliente/");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var clientes = JsonConvert.DeserializeObject<List<ClienteDTO>>(content);
                return clientes;
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
