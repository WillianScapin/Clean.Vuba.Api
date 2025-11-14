using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Vuba.Domain.Interfaces;


namespace Vuba.Domain.Entities
{
    public class JwtAuthenticationService : Interfaces.IJwtAuthenticationService
    {
        public readonly string _jwtSecret;

        public JwtAuthenticationService(IConfiguration configuration)
        {
            _jwtSecret = configuration.GetSection("JwtSecret").Value;
        }

        //Modelo para gerar um token jwt
        
        public string GenerateToken(int AccountId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("AccountId", AccountId.ToString())
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
        public void SetTokenCookie(HttpContext context, string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Lax,
                Expires = DateTime.UtcNow.AddHours(1)
            };

            context.Response.Cookies.Append("JwtToken", token, cookieOptions);
        }

        public int GetTokenInfo(HttpRequest Request)
        {
            //Leio meu token
            var header = Request.Headers.FirstOrDefault(h => h.Key.Equals("Authorization"));

            //Pego meu token
            var token = header.Value.First().Replace("Bearer ", "");

            //Crio um objeto para ler meu jwt
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            var claims = jwtSecurityToken.Claims.ToList();

            int id = int.Parse(claims[0].Value);

            return id;
        }
        
    }
}
