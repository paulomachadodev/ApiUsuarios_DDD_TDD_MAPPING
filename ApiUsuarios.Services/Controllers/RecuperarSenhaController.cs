using ApiUsuarios.Application.Interfaces;
using ApiUsuarios.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuperarSenhaController : ControllerBase
    {
        private readonly IUsuarioAppService? _usuarioAppService;

        public RecuperarSenhaController(IUsuarioAppService? usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public IActionResult Post(RecuperarSenhaPostModel model)
        {
            try
            {
                var usuario = _usuarioAppService.RecuperarSenha(model);

                //HTTP 200 => OK
                return StatusCode(200, new
                {
                    message = "Recuperação de senha realizada com sucesso.",
                    usuario //dados do usuário
                });
            }
            catch (ArgumentException e)
            {
                //HTTP 400 => BAD REQUEST
                return StatusCode(400, new
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



