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
    public class ServiceFuncionario : IServiceFuncionario
    {
        private readonly HttpClient httpClient;
        public ServiceFuncionario(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }
        public async Task<FuncionarioDTO> Actualizar(FuncionarioDTO funcionarioDTO, string token)
        {
            if (funcionarioDTO == null) throw new Exception("No existe el modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Funcionario/Actualizar", funcionarioDTO);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var funcionario = JsonConvert.DeserializeObject<FuncionarioDTO>(content);
                return funcionario;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<FuncionarioDTO> Agregar(FuncionarioDTO funcionarioDTO, string token)
        {
            if (funcionarioDTO == null) throw new Exception("No existe el modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Funcionario", funcionarioDTO);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var funcionario = JsonConvert.DeserializeObject<FuncionarioDTO>(content);
                return funcionario;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<TipoContratoDTO> AgregarTipoContrato(TipoContratoDTO tipoContratoDTO, string token)
        {
            if (tipoContratoDTO == null) throw new Exception("No existe el modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Funcionario/TipoContratoNuevo", tipoContratoDTO);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tc = JsonConvert.DeserializeObject<TipoContratoDTO>(content);
                return tc;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<int> CantidadActivos(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync("/api/Funcionario/CantidadFuncionariosActivos");
            var content = await response.Content.ReadAsStringAsync();
            var cantidad = JsonConvert.DeserializeObject<int>(content);
            return cantidad;
        }

        public async Task<bool> Eliminar(ModelBajaFuncionario bajaFuncionario, string token)
        {
            if (bajaFuncionario.Id < 1) throw new Exception("No existe el usuario");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Funcionario/Baja",bajaFuncionario);

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

        public async Task<bool> FuncionarioDuplicado(GeneralTransport datoCedula, string token)
        {
            if (datoCedula == null) throw new Exception("No existe el modelo");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Funcionario/FuncionarioDuplicado", datoCedula);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var estaDuplicado = JsonConvert.DeserializeObject<bool>(content);
                return estaDuplicado;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<bool> Importar(List<FuncionarioImport> funcionariosDTO, string token)
        {
            if (funcionariosDTO == null || funcionariosDTO.Count == 0) throw new Exception("No existe el modelo");
            ModelListFuncionariosImport modelImport = new()
            {
                FuncionariosImport = funcionariosDTO
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync("/api/Funcionario/ImportarFuncionariosExcel/", modelImport);

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

        public Task<FuncionarioDTO> Obtener(int Id, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FuncionarioDTO>> ObtenerFiltro(FiltroBusquedaFuncionario filtro, string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("No existe usuario");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Funcionario/Filtro", filtro);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var funcionario = JsonConvert.DeserializeObject<List<FuncionarioDTO>>(content);
                return funcionario;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<ModelFunContratosMop> ObtenerTipoContratosMOP(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("No existe usuario");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync($"/api/Funcionario/TipoContratoMOP");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<ModelFunContratosMop>(content);
                return model;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<List<FuncionarioDTO>> ObtenerTodos(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("No existe usuario");
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync($"/api/Funcionario/");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var funcionarios = JsonConvert.DeserializeObject<List<FuncionarioDTO>>(content);
                return funcionarios;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<FuncionarioDTO> ObtenerFuncionarioSegunNumero(int? numeroFuncionario, string token)
        {
            if (numeroFuncionario == null) throw new Exception("Error en la numeracion.");

            GeneralTransport generalTransport = new()
            {
                Valor = numeroFuncionario.Value
            };

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Funcionario/ObtenerFuncionarioSegunNumero", generalTransport);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var funcionario = JsonConvert.DeserializeObject<FuncionarioDTO>(content);
                return funcionario;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(error.ErrorMensaje);
            }
        }

        public async Task<List<FuncionarioDTO>> BusquedaFuncionariosEnMesa(GeneralTransport dato, string token)
        {
            if (dato == null) throw new Exception("No ha escrito niguna referencia para la busqueda de funcionarios");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsJsonAsync($"/api/Funcionario/BusquedaFuncionarioEnMesa",dato);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var funcionarios = JsonConvert.DeserializeObject<List<FuncionarioDTO>>(content);
                return funcionarios;
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
