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
    public class CriarContaTest
    {
        [Fact]
        public async Task Test_Post_CriarConta_Returns_Created()
        {
            var testHelper = new TestHelper();
            var faker = new Faker("pt_BR");

            //criando os dados para cadastrar um usuário
            var model = new CriarContaPostModel
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Telefone = "21999990000",
                Senha = "@Teste1234"
            };

            //serializando os dados em JSON
            var content = testHelper.CreateContent(model);

            //enviando a requisição para a API
            var result = await testHelper.CreateClient().PostAsync("/api/CriarConta", content);

            //verificar o resultado obtido no teste
            result.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Test_Post_CriarConta_Returns_BadRequest()
        {
            var testHelper = new TestHelper();
            var faker = new Faker("pt_BR");

            var model = new CriarContaPostModel
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Telefone = "21999990000",
                Senha = "@Teste1234"
            };

            var content = testHelper.CreateContent(model);
            HttpResponseMessage result = null;

            for (int i = 1; i <= 2; i++)
                result = await testHelper.CreateClient().PostAsync("/api/CriarConta", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.BadRequest);
        }
    }
}
