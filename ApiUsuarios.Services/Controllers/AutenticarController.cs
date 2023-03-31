using ApiUsuarios.Services.Configurations.Jwt;
using ApiUsuarios.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiUsuarios.Application.Interfaces;

namespace ApiUsuarios.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticarController : ControllerBase
    {
        //atributos
        private readonly JwtTokenCreator? _jwtTokenCreator;
        private readonly IUsuarioAppService _usuarioAppService;

        //construtor com entrada de argumentos (injeção de dependência)
        public AutenticarController(JwtTokenCreator? jwtTokenCreator, IUsuarioAppService usuarioAppService)
        {
            _jwtTokenCreator = jwtTokenCreator;
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public IActionResult Post(AutenticarPostModel model)
        {
            try
            {
                var usuario = _usuarioAppService.Autenticar(model);

                //HTTP 200 => OK
                return StatusCode(200, new
                {
                    message = "Usuário autenticado com sucesso",
                    usuario, //dados do usuário
                    token = _jwtTokenCreator.GenerateToken(usuario.Email)
                });
            }
            catch (ArgumentException e)
            {
                //HTTP 401 => UNAUTHORIZED
                return StatusCode(401, new
                {
                    error = e.Message
                });
            }
            catch (Exception e)
            {
                //HTTP 500 => INTERNAL SERVER ERROR
                return StatusCode(500, new
                {
                    error = e.Message
                });
            }
        }
    }
}



