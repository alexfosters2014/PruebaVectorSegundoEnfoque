using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IRepositorios
{
    public interface IRepoRegistroHorario
    {
        public Task<bool> RegistrarHorarioFuncionario(OperativaDiariaDTO operativa);
    }
}
