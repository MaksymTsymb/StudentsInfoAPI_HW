using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using DataAccessLayer.Models;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;

namespace BusinessLayer.Services
{
    public class SessionService : ISessionService
    {
        private readonly AppSettings appSettings;

        public SessionService(IOptions<AppSettings> options)
        {
            appSettings = options.Value;
        }

        public string CreateAuthenthicationToken(UserWithRoles user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            var claims = user.Roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
            claims.Add(new Claim(ClaimTypes.Name, user.UserId.ToString()));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}