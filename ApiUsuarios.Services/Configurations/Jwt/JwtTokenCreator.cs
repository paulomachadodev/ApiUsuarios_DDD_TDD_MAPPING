using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiUsuarios.Services.Configurations.Jwt
{
    public class JwtTokenCreator
    {
        //atributo
        private readonly JwtSettings? _jwtSettings;

        //construtor com entrada de argumentos (injeção de dependência)
        public JwtTokenCreator(IOptions<JwtSettings>? jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        /// <summary>
        /// Método para gerar os TOKENS JWT da API
        /// </summary>
        /// <param name="user">Identificação do usuário</param>
        public string GenerateToken(string user)
        {            
            var tokenHandler = new JwtSecurityTokenHandler();

            //capturar a chave secreta antifalsificação (SecretKey)
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            //montar o conteudo do token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //escrever a identificação do usuário no token
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, user) }),

                //definindo a data de expiração do token
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.Expiration.Value),

                //escrevendo a chave antifalsificação do token (SecretKey)
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            //gerando e retornando o token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
