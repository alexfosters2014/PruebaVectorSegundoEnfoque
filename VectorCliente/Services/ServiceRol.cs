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
    public class ServiceRol : IServiceRol
    {
        private readonly HttpClient httpClient;
        public ServiceRol(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }
        public async Task<RolDTO> Actualizar(RolDTO RolDTO, string token)
        {
            if (RolDTO == null) throw new Exception("No existe el modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Rol/Actualizar", RolDTO);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var mop = JsonConvert.DeserializeObject<RolDTO>(content);
                return mop;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<RolDTO> Agregar(RolDTO RolDTO, string token)
        {
            if (RolDTO == null) throw new Exception("No existe el modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Rol/Agregar", RolDTO);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var mop = JsonConvert.DeserializeObject<RolDTO>(content);
                return mop;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public Task<bool> Eliminar(int Id, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RolDTO>> ObtenerTodos(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("No existe token");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync($"/api/Rol");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var mop = JsonConvert.DeserializeObject<List<RolDTO>>(content);
                return mop;
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
