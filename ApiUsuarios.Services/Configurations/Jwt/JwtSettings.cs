namespace ApiUsuarios.Services.Configurations.Jwt
{
    public class JwtSettings
    {
        public string? SecretKey { get; set; }
        public int? Expiration { get; set; }
    }
}
