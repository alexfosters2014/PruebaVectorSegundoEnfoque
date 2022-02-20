using Modelo;
using Modelo.OtherModels;
using Modelo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IRepositorios
{
    public interface IRepoFuncionario
    {
        public Task<List<FuncionarioDTO>> ObtenerTodos();
        public Task<List<FuncionarioDTO>> ObtenerActivos();
        public Task<List<FuncionarioDTO>> ObtenerBajas();
        public Task<List<FuncionarioDTO>> ObtenerFiltro(FiltroBusquedaFuncionario filtro);

        public Task<FuncionarioDTO> Agregar(FuncionarioDTO modelo);
        public Task<FuncionarioDTO> Actualizar(FuncionarioDTO modelo);
        public Task<bool> DarBaja(ModelBajaFuncionario modelo);

        public Task<List<FuncionarioDTO>> ObtenerTodosActivosSegunMOP(GeneralTransport modelo);
        public Task<bool> FuncionarioDuplicado(GeneralTransport modelo);
        public Task<bool> ImportarFuncionarios(List<FuncionarioImport> modelo);
        public Task<int> CantidadActivos();
        public Task<FuncionarioDTO> ObtenerFuncionarioNumero(GeneralTransport generalTransport);
        public Task<List<FuncionarioDTO>> BusquedaFuncionariosEnMesaOperativaActivos(GeneralTransport busqueda);

    }
}
