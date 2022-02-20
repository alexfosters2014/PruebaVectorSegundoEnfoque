using Comun;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modelo;
using Modelo.OtherModels;
using Modelo.ViewModels;
using Negocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace VectorWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IRepoUsuario repoUsuario;
        private readonly IRepoRol repoRol;
        private readonly IRepoMesaOperativa repoMesaOperativa;
        private readonly IConfiguration configuration;

        public UsuarioController(IRepoUsuario _repoUsuario, IConfiguration _configuration, IRepoRol _repoRol,
                                IRepoMesaOperativa _repoMesaOperativa)
        {
            repoUsuario = _repoUsuario;
            repoRol = _repoRol;
            repoMesaOperativa = _repoMesaOperativa;
            configuration = _configuration;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] VMLogin vmLogin)
        {
            if (vmLogin != null)
            {
                var usuario = await repoUsuario.Login(vmLogin);
                if (usuario == null)
                {
                    return BadRequest(new ErrorModel("Contraseña y/o usuario incorrecto", HttpStatusCode.BadRequest));
                }

                // Leemos el secret_key desde nuestro appseting
                var secretKey = configuration.GetValue<string>("SecretKey");
                var key = Encoding.ASCII.GetBytes(secretKey);

                // Creamos los claims (pertenencias, características) del usuario
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email)
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    // Nuestro token va a durar un día
                    Expires = DateTime.UtcNow.AddDays(1),
                    // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                var token = tokenHandler.WriteToken(createdToken);

                usuario.Token = token;

                return Ok(usuario);
            }
            else
            {
                return BadRequest(new ErrorModel("Debe ingresar usuario y contraseña",HttpStatusCode.BadRequest));
            }
        }

        [AllowAnonymous]
        [HttpGet("{pass}")]
        public async Task<IActionResult> Contrasenia(string pass)
        {
            //return Ok(Encriptacion.Encriptar(pass));
            return Ok(Encriptacion.GetSHA256(pass));
        }

        [HttpGet("Todos")]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            var usuario = await repoUsuario.Obtener();
            if (usuario == null)
            {
                return BadRequest(new ErrorModel("Contraseña y/o usuario incorrecto", HttpStatusCode.BadRequest));
            }
            return Ok(usuario);
        }

        [HttpGet("TodosUsuariosRolesMesaOp")]
        public async Task<IActionResult> ObtenerUsuariosRolesMesaOp()
        {
            var usuarios = await repoUsuario.Obtener();
            var roles = await repoRol.Obtener();
            var mesasOp = await repoMesaOperativa.Obtener();

            if (usuarios == null || roles == null || mesasOp == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            ModelUsuariosRolesMOP resultado = new()
            {
              usuariosDTO = usuarios,
              rolesDTO = roles,
              mesasOpDTO = mesasOp
            };
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarNuevoUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var usuario = await repoUsuario.Agregar(usuarioDTO);
            if (usuario == null)
            {
                return BadRequest(new ErrorModel("No se pudo registrar el nuevo usuario", HttpStatusCode.BadRequest));
            }
            return Ok(usuario);
        }

        [HttpDelete("{usuarioId}")]
        public async Task<IActionResult> EliminarUsuario(int? usuarioId)
        {
            if (usuarioId == null)
            {
                return BadRequest(new ErrorModel("Hubo un error", HttpStatusCode.BadRequest));
            }
            var eliminado = await repoUsuario.Eliminar(usuarioId.Value);
            if (!eliminado)
            {
                return BadRequest(new ErrorModel("No se ha podido eliminar", HttpStatusCode.BadRequest));
            }
            return Ok(eliminado);
        }
    }
}
