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
    public class ServiceMesaOperativa : IServiceMesaOperativa
    {
        private readonly HttpClient httpClient;
        public ServiceMesaOperativa(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }
        public async Task<MesaOperativaDTO> Actualizar(MesaOperativaDTO mesaOperativaDTO, string token)
        {
            if (mesaOperativaDTO == null) throw new Exception("No existe el modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/MesaOperativa/Actualizar", mesaOperativaDTO);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var mop = JsonConvert.DeserializeObject<MesaOperativaDTO>(content);
                return mop;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<MesaOperativaDTO> Agregar(MesaOperativaDTO mesaOperativaDTO, string token)
        {
            if (mesaOperativaDTO == null) throw new Exception("No existe el modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/MesaOperativa/Agregar", mesaOperativaDTO);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var mop = JsonConvert.DeserializeObject<MesaOperativaDTO>(content);
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

        public async Task<List<MesaOperativaDTO>> ObtenerTodos(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("No existe token");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync($"/api/MesaOperativa");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var mop = JsonConvert.DeserializeObject<List<MesaOperativaDTO>>(content);
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
