using Comun;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Modelo.OtherModels;
using Modelo.ViewModels;
using Negocio.IRepositorios;
using Negocio.Repositorios;
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
    public class EscalafonOperativoController : Controller
    {
        //private readonly RepoEscalafonOperativo repoEscalafonOperativo;
        //private readonly IRepoServicio repoServicio;
        //private readonly IRepoAusencia repoAusencia;
        //private readonly IRepoCliente repoCliente;
        //private readonly IRepoFuncionario repoFuncionario;
        //private readonly IRepoRegistroHorario repoRegistroHorario;

        //public EscalafonOperativoController(RepoEscalafonOperativo _repoEscalafonOperativo, IRepoServicio _repoServicio, IRepoCliente _repoCliente,
        //                            IRepoAusencia _repoAusencia, IRepoFuncionario _repoFuncionario, IRepoRegistroHorario _repoRegistroHorario)
        //{
        //    repoEscalafonOperativo = _repoEscalafonOperativo;
        //    repoServicio = _repoServicio;
        //    repoAusencia = _repoAusencia;
        //    repoFuncionario = _repoFuncionario;
        //    repoCliente = _repoCliente;
        //    repoRegistroHorario = _repoRegistroHorario;
        //}

        //[HttpPost("ExisteFechaEscalafon")]
        //public async Task<IActionResult> ExisteEscalafonDiario([FromBody] GeneralTransport modelo)
        //{
        //    bool existe = await repoEscalafonOperativo.ExisteFechaEscalafon(modelo);
        //    return Ok(existe);
        //}

        //[HttpPost("AbrirEscalafon")]
        //public async Task<IActionResult> AbrirEscalafonDiario([FromBody] GeneralTransport modelo)
        //{
        //    bool existePlanificacion = await repoEscalafonOperativo.ExisteFechaEscalafon(modelo);
        //    if (!existePlanificacion)
        //    {
        //        return BadRequest(new ErrorModel("No existe la planificación de la fecha seleccionada", HttpStatusCode.BadRequest));
        //    }
        //    List<ServicioDTO> servicios = await repoServicio.ObtenerTodosActivosSegunMesaOperativa(modelo);
        //    List<ComputoDTO> computos = await repoEscalafonOperativo.ObtenerComputos();
        //    computos.RemoveAll(rem => rem.NombreDescriptivo == SD.ComputosEnum.BAJA.ToString());
        //    List<AusenciaDTO> ausencias = await repoAusencia.ObtenerEnFecha(modelo);

        //    Dictionary<string, ClienteDTO> clientesIteracion = new Dictionary<string, ClienteDTO>();
        //    List<ClienteDTO> clientes = new List<ClienteDTO>();
        //    foreach (var servicio in servicios)
        //    {
        //        if (!clientesIteracion.ContainsKey(servicio.Cliente.RazonSocial))
        //            clientesIteracion.Add(servicio.Cliente.RazonSocial, servicio.Cliente);
        //    }

        //    clientes = clientesIteracion.Values.ToList().OrderByDescending(d => d.Id).ToList();

        //    List<FuncionarioDTO> funcionariosOp = await repoFuncionario.ObtenerTodosActivosSegunMOP(modelo);

        //    List<OperativaDiariaDTO> planificacionesDTO = await repoEscalafonOperativo.ObtenerPlanificacionesOperativasSegunMesaEnFecha(modelo);
        //    List<OperativaDiariaDTO> auxEstados = new();

        //    EscalafonOperativoDiario escalafonModel = new()
        //    {
        //        ServiciosDTO = servicios,
        //        AusenciasDTO = ausencias,
        //        ClientesDTO = clientes,
        //        planesDiarios = planificacionesDTO,
        //        ComputosDTO = computos,
        //        funcionariosDTO = funcionariosOp
        //    };

        //    return Ok(escalafonModel);
        //}

        //[HttpPost("AgregarActualizarPlanDiario")]
        //public async Task<IActionResult> AgregarPlanDiario([FromBody] OperativaDiariaDTO modelo)
        //{
        //    try
        //    {
        //        OperativaDiariaDTO plan = new();
        //        if (modelo.Id == 0)
        //        {
        //            plan = await repoEscalafonOperativo.AgregarPlanDiario(modelo);
        //        }
        //        if (modelo.Id > 0)
        //        {
        //            plan = await repoEscalafonOperativo.ActualizarPlanDiario(modelo);
        //        }
        //        return Ok(plan);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
        //    }

        //}

        //[HttpPost("AgregarNombrePuesto")]
        //public async Task<IActionResult> AgregarPlanDiario([FromBody] NombrePuestoDTO modelo)
        //{
        //    try
        //    {
        //        if (modelo == null)
        //        {
        //            return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
        //        }
        //        NombrePuestoDTO np = await repoEscalafonOperativo.AgregarNombrePuesto(modelo);
        //        if (np == null)
        //        {
        //            return BadRequest(new ErrorModel("No se pudo registrar el nombre de puesto", HttpStatusCode.BadRequest));
        //        }
        //        return Ok(np);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
        //    }

        //}

        //[HttpPost("ObtenerNombresPuestos")]
        //public async Task<IActionResult> ObtenerNombresPuestos([FromBody] GeneralTransport modelo)
        //{
        //    try
        //    {
        //        if (modelo == null)
        //        {
        //            return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
        //        }
        //        List<NombrePuestoDTO> np = await repoEscalafonOperativo.ObtenerNombresPuestos(modelo);

        //        return Ok(np);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new ErrorModel(ex.Message, HttpStatusCode.BadRequest));
        //    }

        //}

        //[HttpDelete("EliminarEstado/{id}")]
        //public async Task<IActionResult> EliminarEstado(int? id)
        //{
        //    try
        //    {
        //        if (id == null)
        //        {
        //            return BadRequest(new ErrorModel("No hay ningun id seleccionado", HttpStatusCode.BadRequest));
        //        }
        //        bool resultado = await repoEscalafonOperativo.EliminarPlanDiario(id.Value);
        //        if (!resultado)
        //        {
        //            return BadRequest(new ErrorModel("No se pudo eliminar el estado", HttpStatusCode.BadRequest));
        //        }
        //        return Ok(resultado);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}



        //[HttpPost("CheckIn")]
        //public async Task<IActionResult> RealizarChekIn([FromBody] OperativaDiariaDTO opDiariaDTO)
        //{
        //    try
        //    {
        //        try
        //        {
        //            {
        //                return BadRequest(new ErrorModel("No hay ningun estado seleccionado", HttpStatusCode.BadRequest));
        //            }
        //            bool resultado = await repoEscalafonOperativo.ActualizarSoloPlanDiario(opDiariaDTO);

        //            if (!resultado)
        //            {
        //                return BadRequest(new ErrorModel("No se pudo eliminar el estado", HttpStatusCode.BadRequest));
        //            }
        //            return Ok(resultado);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }

        //    }catch(Exception ex)
        //    {
        //        throw new Exception("No se pe puede contabili");
        //    }

        //}

        //[HttpPost("CheckOut")]
        //public async Task<IActionResult> RealizarCheckOut([FromBody] OperativaDiariaDTO opDiariaDTO)
        //{
        //    try
        //    {                                                                                                                                                            
        //        {
        //            return BadRequest(new ErrorModel("No hay ningun estado seleccionado", HttpStatusCode.BadRequest));
        //        }
        //        bool resultado = await repoEscalafonOperativo.ActualizarSoloPlanDiario(opDiariaDTO);
        //        if (resultado)
        //        {
        //            bool opDiariaIngresado= await repoRegistroHorario.RegistrarHorarioFuncionario(opDiariaDTO);
        //        }
        //        if (!resultado)
        //        {
        //            return BadRequest(new ErrorModel("No se pudo eliminar el estado", HttpStatusCode.BadRequest));
        //        }
        //        return Ok(resultado);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}
    }
}
