using Modelo;
using Modelo.OtherModels;
using Modelo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VectorCliente.Services.IServices
{
    public interface IServiceFuncionario
    {
        public Task<FuncionarioDTO> Agregar(FuncionarioDTO funcionarioDTO, string token);
        public Task<FuncionarioDTO> Actualizar(FuncionarioDTO funcionarioDTO, string token);
        public Task<FuncionarioDTO> Obtener(int Id, string token);
        public Task<List<FuncionarioDTO>> ObtenerTodos(string token);
        public Task<List<FuncionarioDTO>> ObtenerFiltro(FiltroBusquedaFuncionario filtro, string token);
        public Task<bool> Eliminar(ModelBajaFuncionario bajaFuncionario, string token);
        public Task<ModelFunContratosMop> ObtenerTipoContratosMOP(string token);
        public Task<TipoContratoDTO> AgregarTipoContrato(TipoContratoDTO tipoContratoDTO, string token);
        public Task<bool> FuncionarioDuplicado(GeneralTransport datoCedula, string token);
        public Task<bool> Importar(List<FuncionarioImport> funcionariosDTO, string token);
        public Task<int> CantidadActivos(string token);
        public Task<List<FuncionarioDTO>> BusquedaFuncionariosEnMesa(GeneralTransport dato, string token);
        public Task<FuncionarioDTO> ObtenerFuncionarioSegunNumero(int? numeroFuncionario, string token);


    }
}
