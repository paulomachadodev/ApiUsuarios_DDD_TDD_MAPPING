using ApiUsuarios.Domain.DTOs;
using ApiUsuarios.Domain.Helpers;
using ApiUsuarios.Domain.Interfaces.Messages;
using ApiUsuarios.Domain.Interfaces.Repositories;
using ApiUsuarios.Domain.Interfaces.Services;
using ApiUsuarios.Domain.Models;
using Bogus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Services
{
    /// <summary>
    /// Classe de serviços de domínio para Usuario
    /// </summary>
    public class UsuarioDomainService : IUsuarioDomainService
    {
        //atributos
        private readonly IUsuarioRepository? _usuarioRepository;
        private readonly IMessageProducer? _messageProducer;

        //construtor para inicialização dos atributos (injeção de dependência)
        public UsuarioDomainService(IUsuarioRepository? usuarioRepository, IMessageProducer? messageProducer)
        {
            _usuarioRepository = usuarioRepository;
            _messageProducer = messageProducer;
        }

        public void CriarUsuario(Usuario usuario)
        {
            #region Não permitir o cadastro de usuários com o mesmo email

            if (_usuarioRepository.Get(u => u.Email.Equals(usuario.Email)) != null)
                throw new ArgumentException("O email informado já está cadastrado no sistema. Tente outro.");

            #endregion

            #region Criptografar a senha do usuário

            usuario.Senha = MD5Helper.Encrypt(usuario.Senha);

            #endregion

            _usuarioRepository.Add(usuario);
        }

        public Usuario Autenticar(string email, string senha)
        {
            #region Consultar os dados do usuário através do email e da senha

            senha = MD5Helper.Encrypt(senha);
            var usuario = _usuarioRepository.Get(u => u.Email.Equals(email) && u.Senha.Equals(senha));

            if (usuario == null)
                throw new ArgumentException("Acesso negado, usuário não encontrado.");

            #endregion

            return usuario;
        }

        public Usuario RecuperarSenha(string email)
        {
            #region Consultar os dados do usuário através do email

            var usuario = _usuarioRepository.Get(u => u.Email.Equals(email));
            if (usuario == null)
                throw new ArgumentException("Usuário inválido, verifique o email informado.");

            #endregion

            #region Gerando uma nova senha para o usuário e atualizar no banco de dados

            var faker = new Faker();
            var novaSenha = $"{faker.Internet.Password(8)}@";

            usuario.Senha = MD5Helper.Encrypt(novaSenha);
            _usuarioRepository.Update(usuario);

            #endregion

            #region Enviar para uma fila a solicitação de envio de emails

            var emailMessageDTO = new EmailMessageDTO
            {
                MailTo = usuario.Email,
                Subject = "Recuperação de senha de acesso - API Usuários",
                IsBodyHtml = true,
                Body = $@"
                    <div>
                        <p>Olá {usuario.Nome}, uma nova senha foi gerada com sucesso.</p>
                        <p>Utilize a senha <strong>{novaSenha}</strong> para acessar sua conta.</p>
                        <p>Atenciosamente,</p>
                        <p>Equipe API Usuários.</p>
                    </div>
                "
            };

            //enviar a mensagem para a fila do RabbitMQ
            _messageProducer.Send(JsonConvert.SerializeObject(emailMessageDTO));

            #endregion

            return usuario;
        }
    }
}



