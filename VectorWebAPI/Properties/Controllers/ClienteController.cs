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
    public class ClienteController : Controller
    {
        private readonly IRepoCliente repoCliente;
        private readonly IRepoServicio repoServicio;

        public ClienteController(IRepoCliente _repoCliente, IRepoServicio _repoServicio)
        {
            repoCliente = _repoCliente;
            repoServicio = _repoServicio;
        }
        /// <summary>
        /// Se registra un nuevo cliente al sistema
        /// </summary>
        /// <param name="clienteDTO"></param>
        /// <returns>La entidad mapeada a DTO del cliente ingresado al sistema</returns>
        [HttpPost]
        public async Task<IActionResult> AgregarNuevoCliente([FromBody] ClienteDTO clienteDTO)
        {
            if (clienteDTO == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var usuario = await repoCliente.Agregar(clienteDTO);
            if (usuario == null)
            {
                return BadRequest(new ErrorModel("No se pudo registrar el cliente", HttpStatusCode.BadRequest));
            }
            return Ok(usuario);
        }

        [HttpPost("Actualizar")]
        public async Task<IActionResult> ActualizarCliente([FromBody] ClienteDTO clienteDTO)
        {
            if (clienteDTO == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var usuario = await repoCliente.Actualizar(clienteDTO);
            if (usuario == null)
            {
                return BadRequest(new ErrorModel("No se pudieron actualizar los datos del cliente", HttpStatusCode.BadRequest));
            }
            return Ok(usuario);
        }

        [HttpDelete("{clienteId}")]
        public async Task<IActionResult> BajaCliente(int? clienteId)
        {
            if (clienteId == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var eliminadoCliente = await repoCliente.DarBaja(clienteId.Value);
            if (!eliminadoCliente)
            {
                return BadRequest(new ErrorModel("No se ha podido dar de baja", HttpStatusCode.BadRequest));
            }
            var elimadoServicios = await repoServicio.DarBajaServicios(clienteId.Value);
            return Ok(elimadoServicios || eliminadoCliente);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var clientes = await repoCliente.ObtenerTodosActivos();
            if (clientes == null)
            {
                return BadRequest(new ErrorModel("No se pudo obtener los clientes", HttpStatusCode.BadRequest));
            }
            return Ok(clientes);
        }
    }
}
