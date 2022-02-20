﻿using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.IRepositorios
{
    public interface IRepoTipoContrato
    {
        public Task<List<TipoContratoDTO>> Obtener();
        public Task<TipoContratoDTO> Agregar(TipoContratoDTO modelo);
    }
}
