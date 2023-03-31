using ApiUsuarios.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para os serviços de domínio de usuário (Regras de negócio)
    /// </summary>
    public interface IUsuarioDomainService
    {
        /// <summary>
        /// Método para implementar o cadastro de um usuário
        /// </summary>
        void CriarUsuario(Usuario usuario);

        /// <summary>
        /// Método para realizar a autenticação do usuário
        /// </summary>
        Usuario Autenticar(string email, string senha);

        /// <summary>
        /// Método para realizar a recuperação da senha do usuário
        /// </summary>
        Usuario RecuperarSenha(string email);
    }
}



