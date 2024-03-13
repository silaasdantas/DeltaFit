using DeltaFit.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DeltaFit.Application.Abstractions.Authentication;
using DeltaFit.Application.Login;

namespace DeltaFit.Infrastructure.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IConfiguration _configuration;

        public JwtProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Jwt GenerateToken(LoginCommand command)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            //var issuer = _configuration.GetRequiredSection("Jwt:Issuer").Value;
            //var audience = _configuration.GetRequiredSection("Jwt:Audience").Value;
            var key = Encoding.ASCII.GetBytes(_configuration.GetRequiredSection("Jwt:Key").Value);
            var createDate = DateTime.Now;
            var expirationDate = createDate + TimeSpan.FromHours(12);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, command.Name),
                    new Claim(ClaimTypes.Role, RoleFactory(command.Type))
                }),
                NotBefore = createDate,
                Expires = expirationDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(securityToken);

            return new()
            {
                Authenticated = true,
                Created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token
            };
        }

        private static string RoleFactory(int roleNumber)
        {
            return roleNumber switch
            {
                1 => "Admin",
                2 => "Trainer",
                3 => "Student",
                _ => throw new Exception()
            };
        }
    }
}