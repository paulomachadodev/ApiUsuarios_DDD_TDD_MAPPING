using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Tests.Helpers
{
    public class TestHelper
    {
        //método capaz de executar o projeto AspNet API
        //conectando o projeto de testes com a API
        public HttpClient CreateClient()
        {
            //criando um cliente HTTP da API
            return new WebApplicationFactory<Program>().CreateClient();
        }

        //método capaz de serializar dados para o formato JSON
        public StringContent CreateContent<T>(T obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj),
                Encoding.UTF8, "application/json");
        }
    }
}



