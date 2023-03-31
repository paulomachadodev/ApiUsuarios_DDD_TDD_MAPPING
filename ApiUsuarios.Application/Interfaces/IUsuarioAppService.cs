using ApiUsuarios.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Application.Interfaces
{
    /// <summary>
    /// Serviço da camada de aplicação para Usuario
    /// </summary>
    public interface IUsuarioAppService
    {
        UsuarioModel CriarConta(CriarContaPostModel model);

        UsuarioModel Autenticar(AutenticarPostModel model);

        UsuarioModel RecuperarSenha(RecuperarSenhaPostModel model);
    }
}
