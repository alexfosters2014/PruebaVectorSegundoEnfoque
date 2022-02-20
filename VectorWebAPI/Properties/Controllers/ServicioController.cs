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
    public class ServicioController : Controller
    {
        private readonly IRepoServicio repoServicio;

        public ServicioController(IRepoServicio _repoServicio)
        {
            repoServicio = _repoServicio;
        }

        [HttpPost]
        public async Task<IActionResult> AgregarNuevoServicio([FromBody] ServicioDTO servicioDTO)
        {
            if (servicioDTO == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var servicio = await repoServicio.Agregar(servicioDTO);
            if (servicio == null)
            {
                return BadRequest(new ErrorModel("No se pudo registrar el cliente", HttpStatusCode.BadRequest));
            }
            return Ok(servicioDTO);
        }

        [HttpPost("Actualizar")]
        public async Task<IActionResult> ActualizarServicio([FromBody] ServicioDTO servicioDTO)
        {
            if (servicioDTO == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var servicio = await repoServicio.Actualizar(servicioDTO);
            if (servicio == null)
            {
                return BadRequest(new ErrorModel("No se pudieron actualizar los datos del cliente", HttpStatusCode.BadRequest));
            }
            return Ok(servicio);
        }

        [HttpDelete("{servicioId}")]
        public async Task<IActionResult> BajaServicio(int? servicioId)
        {
            if (servicioId == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var eliminadoServicio = await repoServicio.DarBaja(servicioId.Value);
            if (!eliminadoServicio)
            {
                return BadRequest(new ErrorModel("No se ha podido dar de baja", HttpStatusCode.BadRequest));
            }
            return Ok(eliminadoServicio);
        }
        [HttpGet("ObtenerPorCliente/{clienteId}")]
        public async Task<IActionResult> ObtenerPorCliente(int? clienteId)
        {
            if (clienteId == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var servicios = await repoServicio.ObtenerPorCliente(clienteId.Value);
            if (servicios == null)
            {
                return BadRequest(new ErrorModel("No se ha podido dar de baja", HttpStatusCode.BadRequest));
            }
            return Ok(servicios);
        }
        [HttpDelete("BajaPorCliente/{clienteId}")]
        public async Task<IActionResult> BajaServicioPorCliente(int? clienteId)
        {
            if (clienteId == null)
            {
                return BadRequest(new ErrorModel("Hubo un error. Codigo de cliente no existe", HttpStatusCode.BadRequest));
            }
            var resultado = await repoServicio.DarBajaServicios(clienteId.Value);
            if (resultado == false)
            {
                return BadRequest(new ErrorModel("No se ha podido dar de baja algun servicio o todos", HttpStatusCode.BadRequest));
            }
            return Ok(resultado);
        }
    }
}
