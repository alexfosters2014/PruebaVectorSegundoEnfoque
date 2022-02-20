using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IRepositorios
{
    public interface IRepoPreferenciaFuncionarioServicio
    {
        public Task<bool> GuardarCambios(List<PreferenciaFuncionarioServicioDTO> preferencias);
        public Task<bool> Eliminar(int IdPref);
        public Task<PreferenciaFuncionarioServicioDTO> Agregar(PreferenciaFuncionarioServicioDTO preferencia);
        public Task<List<PreferenciaFuncionarioServicioDTO>> ObtenerTodos(int idServicio);
    }
}
