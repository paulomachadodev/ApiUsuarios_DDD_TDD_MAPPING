using ApiUsuarios.Application.Interfaces;
using ApiUsuarios.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriarContaController : ControllerBase
    {
        //atributo
        private readonly IUsuarioAppService? _usuarioAppService;

        //construtor para injeção de dependência
        public CriarContaController(IUsuarioAppService? usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public IActionResult Post(CriarContaPostModel model)
        {
            try
            {
                var usuario = _usuarioAppService.CriarConta(model);

                //HTTP 201 => CREATED
                return StatusCode(201, new
                {
                    message = "Usuário cadastrado com sucesso",
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



