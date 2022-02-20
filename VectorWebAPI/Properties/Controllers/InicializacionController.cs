using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class InicializacionController : Controller
    {
        private readonly IInicializacion repoInicializacion;

        public InicializacionController(IInicializacion _repoInicializacion)
        {
            repoInicializacion = _repoInicializacion;
        }

        [HttpGet]
        public async Task<IActionResult> PrecargaDatos()
        {
            try { 
            bool resultado = await repoInicializacion.PrecargaDatos();
            if (resultado) { 
            return Ok(resultado);
            }
            else
            {
                return BadRequest(new ErrorModel("No se pudo inicializar algunos datos", HttpStatusCode.BadRequest));
            }
            }catch(Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
            }
        }
    }
}
