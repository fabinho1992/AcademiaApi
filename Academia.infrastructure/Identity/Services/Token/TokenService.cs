using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Academia.infrastructure.Identity.Services.Token
{
    public class TokenService : ITokenService
    {
        public JwtSecurityToken GenerationAcessToken(IEnumerable<Claim> claims, IConfiguration _config)
        {
            var keyString = _config.GetSection("Jwt").GetValue<string>("SecretKey") ?? throw new InvalidOperationException("Invalid secret Key!!");

            var key = Encoding.UTF8.GetBytes(keyString);

            var assinaturaCredencialChave = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature); // essas 3 variaveis são usadas para armazenar a chave secreta pronta para uso no token

            var descricaoToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_config.GetSection("Jwt")
                                                        .GetValue<double>("TokenValidityInMinutes")),
                Issuer = _config.GetSection("Jwt").GetValue<string>("ValidIssuer"),
                Audience = _config.GetSection("Jwt").GetValue<string>("ValidAudience"),
                SigningCredentials = assinaturaCredencialChave
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(descricaoToken); // aqui crio o token
            return token;
        }
    }
}
