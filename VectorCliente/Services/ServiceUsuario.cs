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
    public class ServiceUsuario : IServiceUsuario
    {
        private readonly HttpClient httpClient;
        public ServiceUsuario(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public async Task<UsuarioDTO> Agregar(UsuarioDTO usuarioDTO, string token)
        {
            if (usuarioDTO == null) throw new Exception("No existe el modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Usuario/", usuarioDTO);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var usuario = JsonConvert.DeserializeObject<UsuarioDTO>(content);
                return usuario;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<bool> Eliminar(int usuarioId, string token)
        {
            if (usuarioId < 1) throw new Exception("No existe el usuario");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.DeleteAsync($"/api/Usuario/{usuarioId}");

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

        public async Task<UsuarioDTO> Login(VMLogin vmLogin)
        {
            if (vmLogin == null) throw new Exception("No existe el modelo");

            var response = await httpClient.PostAsJsonAsync($"/api/Usuario/Login", vmLogin);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var usuario = JsonConvert.DeserializeObject<UsuarioDTO>(content);
                return usuario;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<ModelUsuariosRolesMOP> ObtenerModelUsuarioRolesMOp(string token)
        {
             if (string.IsNullOrEmpty(token))
            {
                throw new Exception("No existe usuario");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync($"/api/Usuario/TodosUsuariosRolesMesaOp");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var modelUs = JsonConvert.DeserializeObject<ModelUsuariosRolesMOP>(content);
                return modelUs;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
            
        }

        public async Task<List<UsuarioDTO>> ObtenerTodos(string token)
        {
           if (string.IsNullOrEmpty(token))
            {
                throw new Exception("No existe usuario");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync($"/api/Usuario/Todos");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var usuario = JsonConvert.DeserializeObject<List<UsuarioDTO>>(content);
                return usuario;
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
