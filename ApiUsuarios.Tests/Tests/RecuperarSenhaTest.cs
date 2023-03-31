using ApiUsuarios.Application.Models;
using ApiUsuarios.Tests.Helpers;
using Bogus;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiUsuarios.Tests.Tests
{
    public class RecuperarSenhaTest
    {
        [Fact]
        public async Task Test_Post_RecuperarSenha_Returns_Ok()
        {
            #region Criar um usuário

            var testHelper = new TestHelper();
            var faker = new Faker("pt_BR");

            var modelCriarConta = new CriarContaPostModel
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Telefone = "21999990000",
                Senha = "@Teste1234"
            };

            var contentCriarConta = testHelper.CreateContent(modelCriarConta);
            await testHelper.CreateClient().PostAsync("/api/CriarConta", contentCriarConta);

            #endregion

            #region Recuperar a senha do usuário

            var modelRecuperarSenha = new RecuperarSenhaPostModel
            {
                Email = modelCriarConta.Email
            };

            var contentRecuperarSenha = testHelper.CreateContent(modelRecuperarSenha);
            var response = await testHelper.CreateClient().PostAsync("/api/RecuperarSenha", contentRecuperarSenha);

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            #endregion
        }

        [Fact]
        public async Task Test_Post_RecuperarSenha_Returns_BadRequest()
        {
            var testHelper = new TestHelper();
            var faker = new Faker("pt_BR");

            var model = new RecuperarSenhaPostModel
            {
                Email = faker.Internet.Email()
            };

            var content = testHelper.CreateContent(model);
            var response = await testHelper.CreateClient().PostAsync("/api/RecuperarSenha", content);

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.BadRequest);
        }
    }
}



