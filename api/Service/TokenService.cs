using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.Interface;
using api.Models;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace api.Service
{
    public class TokenService : ITokenService
    {
        // Configuration to access app settings
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _symmetricSecurityKey;

        // Constructor to inject configuration
        public TokenService(IConfiguration config)
        {
            _config = config;
            _symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["JWT:SigningKey"])
            );
        }

        public string CreateToken(AppUser user)
        { // Define claims for the token
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            // Create signing credentials using the symmetric security key
            var creds = new SigningCredentials(
                _symmetricSecurityKey,
                SecurityAlgorithms.HmacSha256Signature
            );

            // Define the token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"],
            };
            // Create the token handler
            var tokenHandler = new JwtSecurityTokenHandler();
            // Create the token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // Return the serialized token
            return tokenHandler.WriteToken(token);
        }
    }
}
