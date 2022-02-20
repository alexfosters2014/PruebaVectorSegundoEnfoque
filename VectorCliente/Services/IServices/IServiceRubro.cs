using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VectorCliente.Services.IServices
{
    public interface IServiceRubro
    {
        public Task<RubroDTO> AgregarNuevo(RubroDTO rubro, string token);
    }
}
