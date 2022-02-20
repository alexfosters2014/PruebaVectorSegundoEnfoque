using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Modelo.OtherModels;
using Negocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace VectorWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MesaOperativaController : Controller
    {
        private readonly IRepoMesaOperativa repoMesaOperativa;

        public MesaOperativaController(IRepoMesaOperativa _repoMesaOperativa)
        {
            repoMesaOperativa = _repoMesaOperativa;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerMesasOperativas()
        {
            var usuario = await repoMesaOperativa.Obtener();
            if (usuario == null)
            {
                return BadRequest(new ErrorModel("No existe ninguna MesaOperativa en el sistema", HttpStatusCode.BadRequest));
            }
            return Ok(usuario);
        }

        [HttpPost("Actualizar")]
        public async Task<IActionResult> ActualizarMesaOperativa([FromBody] MesaOperativaDTO mesaopDTO)
        {
            if (mesaopDTO == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var mop = await repoMesaOperativa.Actualizar(mesaopDTO);
            if (mop == null)
            {
                return BadRequest(new ErrorModel("No se pudo registrar el nuevo usuario", HttpStatusCode.BadRequest));
            }
            return Ok(mop);
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> AgregarNuevaMesaOperativa([FromBody] MesaOperativaDTO mesaopDTO)
        {
            if (mesaopDTO == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var usuario = await repoMesaOperativa.Agregar(mesaopDTO);
            if (usuario == null)
            {
                return BadRequest(new ErrorModel("No se pudo registrar el nuevo usuario", HttpStatusCode.BadRequest));
            }
            return Ok(usuario);
        }
    }
}
