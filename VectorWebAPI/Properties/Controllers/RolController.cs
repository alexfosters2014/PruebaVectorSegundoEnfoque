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
    public class RolController : Controller
    {
        private readonly IRepoRol repoRol;

        public RolController(IRepoRol _repoRol)
        {
            repoRol = _repoRol;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerRoles()
        {
            var usuario = await repoRol.Obtener();
            if (usuario == null)
            {
                return BadRequest(new ErrorModel("No existe ningun rol en el sistema", HttpStatusCode.BadRequest));
            }
            return Ok(usuario);
        }

        [HttpPost("Actualizar")]
        public async Task<IActionResult> ActualizarRol([FromBody] RolDTO rolDTO)
        {
            if (rolDTO == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var mop = await repoRol.Actualizar(rolDTO);
            if (mop == null)
            {
                return BadRequest(new ErrorModel("No se pudo actualizar el rol seleccionado", HttpStatusCode.BadRequest));
            }
            return Ok(mop);
        }

        [HttpPost("Agregar")]
        public async Task<IActionResult> AgregarNuevoRol([FromBody] RolDTO rolDTO)
        {
            if (rolDTO == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var usuario = await repoRol.Agregar(rolDTO);
            if (usuario == null)
            {
                return BadRequest(new ErrorModel("No se pudo registrar el nuevo rol", HttpStatusCode.BadRequest));
            }
            return Ok(usuario);
        }
    }
}
