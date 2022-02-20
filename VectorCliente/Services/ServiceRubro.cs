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
    public class ServiceRubro : IServiceRubro
    {
        private readonly HttpClient httpClient;
        public ServiceRubro(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }
        public async Task<RubroDTO> AgregarNuevo(RubroDTO rubro, string token)
        {

            if (rubro == null) throw new Exception("No existe modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Funcionario/Rubro", rubro);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var rubroNuevo = JsonConvert.DeserializeObject<RubroDTO>(content);
                return rubroNuevo;
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
