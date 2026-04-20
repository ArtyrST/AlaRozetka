using System;
using AlaBackEnd.DAL.Entity.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;


namespace AlaBackEnd.BLL.Services.LoginService
{
    public class JwtService
    {
        private readonly IConfiguration _config;
        public JwtService(IConfiguration config)
        {
            _config = config;
        }
        public Task<string> GenerateTokenAsync(UserEntity user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                
                

            };
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim("role", role.Name));
            }

            var keyString = _config["Jwt:Key"] ?? throw new InvalidOperationException("JWT configuration value 'Jwt:Key' is missing.");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds

           );

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token)); 
        }
    }
}
