using ApiUsuarios.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Application.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AtualizarDadosController : ControllerBase
    {
        [HttpPut]
        public IActionResult Put(AtualizarDadosPutModel model)
        {
            return Ok();
        }
    }
}
