using ApiUsuarios.Application.Interfaces;
using ApiUsuarios.Application.Models;
using ApiUsuarios.Domain.Interfaces.Services;
using ApiUsuarios.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        //atributos
        private readonly IUsuarioDomainService? _usuarioDomainService;
        private readonly IMapper _mapper;

        //construtor para injeção de dependência
        public UsuarioAppService(IUsuarioDomainService? usuarioDomainService, IMapper mapper)
        {
            _usuarioDomainService = usuarioDomainService;
            _mapper = mapper;
        }

        public UsuarioModel CriarConta(CriarContaPostModel model)
        {
            //transferir os dados da model para a entidade
            var usuario = _mapper.Map<Usuario>(model);

            //cadastrar ó usuário no domínio
            _usuarioDomainService.CriarUsuario(usuario);

            //retornar os dados do usuário criado
            return _mapper.Map<UsuarioModel>(usuario);
        }

        public UsuarioModel Autenticar(AutenticarPostModel model)
        {
            //consultando os dados do usuário no dominio
            var usuario = _usuarioDomainService.Autenticar(model.Email, model.Senha);

            //retornar os dados do usuário criado
            return _mapper.Map<UsuarioModel>(usuario);
        }

        public UsuarioModel RecuperarSenha(RecuperarSenhaPostModel model)
        {
            //gerar a recuperação de senha no domínio
            var usuario = _usuarioDomainService.RecuperarSenha(model.Email);

            //retornar os dados do usuário
            return _mapper.Map<UsuarioModel>(usuario);
        }
    }
}



