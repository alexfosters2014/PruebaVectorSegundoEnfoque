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

namespace VectorWebAPI.Properties.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PreferenciasFuncionariosEnServicioController : Controller
    {
        private readonly IRepoPreferenciaFuncionarioServicio repoPreferenciaFuncionarioServicio;

        public PreferenciasFuncionariosEnServicioController(IRepoPreferenciaFuncionarioServicio _repoPreferenciaFuncionarioServicio)
        {
            repoPreferenciaFuncionarioServicio = _repoPreferenciaFuncionarioServicio;
        }

        [HttpPost]
        public async Task<IActionResult> AgregarNuevaPreferencia([FromBody] PreferenciaFuncionarioServicioDTO prefDTO)
        {
            try
            {

                if (prefDTO == null)
                {
                    return BadRequest(new ErrorModel("Hubo un error. Modelo Vacio", HttpStatusCode.BadRequest));
                }
                PreferenciaFuncionarioServicioDTO resultado = await repoPreferenciaFuncionarioServicio.Agregar(prefDTO);
                if (resultado == null)
                {
                    return BadRequest(new ErrorModel("No se pudo registrar el cliente", HttpStatusCode.BadRequest));
                }
                return Ok(resultado);
            } catch (Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpPost("GuardarCambios")]
        public async Task<IActionResult> GuardarCambiosPreferencias([FromBody] List<PreferenciaFuncionarioServicioDTO> prefsDTO)
        {
            try
            {

                if (prefsDTO == null)
                {
                    return BadRequest(new ErrorModel("Hubo un error. Modelo Vacio", HttpStatusCode.BadRequest));
                }
                bool resultado = await repoPreferenciaFuncionarioServicio.GuardarCambios(prefsDTO);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpDelete("{idPref}")]
        public async Task<IActionResult> BorrarPreferencia(int? idPref)
        {
            try
            {

                if (idPref == null)
                {
                    return BadRequest(new ErrorModel("Hubo un error. Modelo Vacio", HttpStatusCode.BadRequest));
                }
                bool resultado = await repoPreferenciaFuncionarioServicio.Eliminar(idPref.Value);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
            }
        }


        [HttpGet("{idServicio}")]
        public async Task<IActionResult> ObtenerTodos(int? idServicio)
        {
            try
            {
                if (idServicio == null)
                {
                    return BadRequest(new ErrorModel("Hubo un error. Modelo Vacio", HttpStatusCode.BadRequest));
                }
                List<PreferenciaFuncionarioServicioDTO> resultados = await repoPreferenciaFuncionarioServicio.ObtenerTodos(idServicio.Value);
                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
            }
        }

    }
}
