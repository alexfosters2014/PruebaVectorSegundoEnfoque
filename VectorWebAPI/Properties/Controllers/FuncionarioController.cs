using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Modelo.OtherModels;
using Modelo.ViewModels;
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
    public class FuncionarioController : Controller
    {
        private readonly IRepoFuncionario repoFuncionario;
        private readonly IRepoMesaOperativa repoMesaOperativa;
        private readonly IRepoTipoContrato repoTipoContrato;
        private readonly IRepoRubro repoRubro;

        public FuncionarioController(IRepoFuncionario _repoFuncionario, IRepoMesaOperativa _repoMesaOperativa,
                                        IRepoTipoContrato _repoTipoContrato, IRepoRubro _repoRubro)
        {
            repoFuncionario = _repoFuncionario;
            repoMesaOperativa = _repoMesaOperativa;
            repoTipoContrato = _repoTipoContrato;
            repoRubro = _repoRubro;
        }

        [HttpPost]
        public async Task<IActionResult> AgregarNuevoFuncionario([FromBody] FuncionarioDTO funcionarioDTO)
        {
            if (funcionarioDTO == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var funcionario = await repoFuncionario.Agregar(funcionarioDTO);
            if (funcionario == null)
            {
                return BadRequest(new ErrorModel("No se pudo registrar el funcionario", HttpStatusCode.BadRequest));
            }
            return Ok();
        }

        [HttpPost("Actualizar")]
        public async Task<IActionResult> ActualizarFuncionario([FromBody] FuncionarioDTO funcionarioDTO)
        {
            if (funcionarioDTO == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var usuario = await repoFuncionario.Actualizar(funcionarioDTO);
            if (usuario == null)
            {
                return BadRequest(new ErrorModel("No se pudieron actualizar los datos del funcionario", HttpStatusCode.BadRequest));
            }
            return Ok(usuario);
        }

        [HttpPost("ObtenerFuncionarioSegunNumero")]
        public async Task<IActionResult> ObtenerFuncionarioSegunNumero([FromBody] GeneralTransport generalTransport)
        {
            if (generalTransport == null)
            {
                return BadRequest(new ErrorModel("Hubo un error. No se recibieron datos", HttpStatusCode.BadRequest));
            }
            var funcionarioObtenido = await repoFuncionario.ObtenerFuncionarioNumero(generalTransport);
            if (funcionarioObtenido == null)
            {
                return BadRequest(new ErrorModel("No se pudieron obtener los datos del funcionario", HttpStatusCode.BadRequest));
            }
            return Ok(funcionarioObtenido);
        }

        [HttpPost("Baja")]
        public async Task<IActionResult> BajaFuncionario(ModelBajaFuncionario funcionarioBaja)
        {
            if (funcionarioBaja == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var eliminado = await repoFuncionario.DarBaja(funcionarioBaja);
            if (!eliminado)
            {
                return BadRequest(new ErrorModel("No se ha podido dar de baja", HttpStatusCode.BadRequest));
            }
            return Ok(eliminado);
        }

        [HttpPost("Filtro")]
        public async Task<IActionResult> BuscarFuncionariosFiltrados([FromBody] FiltroBusquedaFuncionario filtro)
        {
            if (filtro == null)
            {
                return BadRequest(new ErrorModel("Faltan filtros", HttpStatusCode.BadRequest));
            }
            var funcionarios = await repoFuncionario.ObtenerFiltro(filtro);
            if (funcionarios == null)
            {
                return BadRequest(new ErrorModel("Error en el filtro especificado", HttpStatusCode.BadRequest));
            }
            return Ok(funcionarios);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var funcionarios = await repoFuncionario.ObtenerTodos();
            if (funcionarios == null)
            {
                return BadRequest(new ErrorModel("No se pudo obtener los funcionarios", HttpStatusCode.BadRequest));
            }
            return Ok(funcionarios);
        }
        [HttpGet("CantidadFuncionariosActivos")]
        public async Task<IActionResult> CantidadFuncionariosActivos()
        {
            int cantidad = await repoFuncionario.CantidadActivos();
            return Ok(cantidad);
        }

        [HttpPost("BusquedaFuncionarioEnMesa")]
        public async Task<IActionResult> BusquedaFuncionariosEnMesa([FromBody] GeneralTransport busqueda)
        {
            List<FuncionarioDTO> funcionarios = await repoFuncionario.BusquedaFuncionariosEnMesaOperativaActivos(busqueda);

            if (funcionarios == null)
            {
                return BadRequest(new ErrorModel("Error al obtener datos", HttpStatusCode.BadRequest));
            }
            return Ok(funcionarios);
        }

            [HttpGet("TipoContratoMOP")]
        public async Task<IActionResult> TipoContratosMOP()
        {
            var tiposContratos = await repoTipoContrato.Obtener();
            var mesasOperativas = await repoMesaOperativa.Obtener();
            var rubros = await repoRubro.Obtener();
            if (tiposContratos == null && mesasOperativas == null)
            {
                return BadRequest(new ErrorModel("Error al obtener datos", HttpStatusCode.BadRequest));
            }
            ModelFunContratosMop model = new ModelFunContratosMop()
            {
                MesasOperativas = mesasOperativas,
                TiposContratos = tiposContratos,
                Rubros = rubros
            };
            return Ok(model);
        }

        [HttpPost("TipoContratoNuevo")]
        public async Task<IActionResult> TipoContratoNuevo([FromBody] TipoContratoDTO tipoContrato)
        {
            var tContrato = await repoTipoContrato.Agregar(tipoContrato);
            if (tContrato == null)
            {
                return BadRequest(new ErrorModel("Error al obtener datos", HttpStatusCode.BadRequest));
            }
            return Ok(tContrato);
        }

        [HttpPost("Rubro")]
        public async Task<IActionResult> AgregarRubro([FromBody] RubroDTO rubroDTO)
        {
            if (rubroDTO == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var rubro = await repoRubro.Agregar(rubroDTO);
            if (rubro == null)
            {
                return BadRequest(new ErrorModel("No se pudo registrar el rubro. Verifique que no esté queriendo registrar un rubro duplicado", HttpStatusCode.BadRequest));
            }
            return Ok(rubro);
        }

        [HttpPost("FuncionarioDuplicado")]
        public async Task<IActionResult> TipoContratoNuevo([FromBody] GeneralTransport modelo)
        {
            try
            {
                if (string.IsNullOrEmpty(modelo.Data))
                {
                    return BadRequest(new ErrorModel("No hay dato", HttpStatusCode.BadRequest));
                }
                bool esDuplicado = await repoFuncionario.FuncionarioDuplicado(modelo);
                return Ok(esDuplicado);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error");
            }
        }
        [AllowAnonymous]
        [HttpPost("ImportarFuncionariosExcel")]
        public async Task<IActionResult> ImportarFuncionariosDesdeExcel([FromBody] ModelListFuncionariosImport modelo)
        {
            try
            {
                if (modelo == null || modelo.FuncionariosImport.Count == 0)
                {
                    return BadRequest(new ErrorModel("No hay dato", HttpStatusCode.BadRequest));
                }
                bool registroImportacionFun = await repoFuncionario.ImportarFuncionarios(modelo.FuncionariosImport);
                return Ok(registroImportacionFun);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error");
            }
        }


    }
}
