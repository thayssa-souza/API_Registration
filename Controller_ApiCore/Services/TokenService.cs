using ApiBanco.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiBanco.Core.Services
{
    public class TokenService : ITokenService
    {
        public IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateTokenProdutos(string nome, string permissao)
        {
            //chave secreta para validação do Token contida no appsetings
            //enconding para converter para bytes
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("secretKey"));

            //corpo do JWT
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "APIClientes.com", //quem emitiu o token
                Audience = "APIEvents.com", //quem vai receber o token
                Subject = new ClaimsIdentity(new Claim[]
                {//infos do sujeito autenticado no token
                    new Claim(ClaimTypes.Name, nome),
                    new Claim(ClaimTypes.Role, permissao), //se é admin ou cliente por ex
                    //permissao criada no banco com admin e cliente
                    new Claim("teste", "123")
                }),
                Expires = DateTime.UtcNow.AddMinutes(15), //o token costuma expirar em 15 min
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), //chave simétrica, permitindo o compartilhamento da chave entre as APis
                SecurityAlgorithms.HmacSha256Signature) //segurança do algoritmo
            };

            //classe para gerar e manipular o token
            var tokenHandler = new JwtSecurityTokenHandler();

            //criando a estrutura do token:
            var token = tokenHandler.CreateToken(tokenDescriptor);

            //vai serializar, transformar o token criado e criptografá-lo
            return tokenHandler.WriteToken(token);
        }
    }
}
