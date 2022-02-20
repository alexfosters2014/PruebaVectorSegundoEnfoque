using Modelo.OtherModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace VectorCliente.Services
{
    public class ServiceInicializar
    {
        private readonly HttpClient httpClient;
        public ServiceInicializar(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }
        public async Task<bool> PrecargaDatos()
        {
            var response = await httpClient.GetAsync("/api/Inicializacion/");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var funcionario = JsonConvert.DeserializeObject<bool>(content);
                return funcionario;
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
