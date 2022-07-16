using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiAutores.Entidades;

namespace WebApiAutores.Services
{
    public class TokenService : ItokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));


        }
        public string CreateToken(User user)
        {
            var claims = new List<Claim>()
            {

                new Claim(JwtRegisteredClaimNames.NameId, user.UserName) // EL claim ira el id y el username
            };

            var credentials = new  SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature); // para poder crear esto se necesita un key y un algoritmo 

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = credentials
                
            };

            var TokenHandler = new JwtSecurityTokenHandler();
            var token = TokenHandler.CreateToken(tokenDescriptor); // ACA CREO EL TOKEN CON LAS CARCATERISTICAS QUE TIENE EL TOKEN DESCRIPTOR

            return TokenHandler.WriteToken(token);

        }
    }
}
