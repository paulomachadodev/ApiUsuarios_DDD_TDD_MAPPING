using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiUsuarios.Services.Configurations.Jwt
{
    public class JwtConfiguration
    {
        /// <summary>
        /// Método para configurar a politica de autenticação
        /// do projeto por meio do framework JWT - JSON WEB TOKENS
        /// </summary>
        public static void Configure(WebApplicationBuilder builder)
        {
            //lendo as configurações contidas no arquivo /appsettings.json
            //e copia os valores para a classe JwtSettings
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

            //registrando a classe JwtTokenCreator
            builder.Services.AddTransient<JwtTokenCreator>();

            //definindo a política de autenticação do projeto
            builder.Services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer(
                bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes
                                (builder.Configuration.GetSection("JwtSettings").GetSection("SecretKey").Value)
                            ),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });
        }
    }
}
