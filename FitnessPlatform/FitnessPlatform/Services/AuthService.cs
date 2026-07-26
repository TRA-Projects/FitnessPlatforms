using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitnessPlatform.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string GenerateToken(
            int userId,
            string username,
            string role)
        {

            var claims = new[]
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    userId.ToString()),

                new Claim(
                    ClaimTypes.Name,
                    username),

                new Claim(
                    ClaimTypes.Role,
                    role)
            };


            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                _configuration["JwtSettings:SecretKey"]!)
            );


            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );


            var token = new JwtSecurityToken(

                issuer:
                _configuration["JwtSettings:Issuer"],

                audience:
                _configuration["JwtSettings:Audience"],

                claims: claims,

                expires:
                DateTime.Now.AddHours(
                Convert.ToDouble(
                _configuration["JwtSettings:ExpiryHours"])),

                signingCredentials:
                credentials
            );


            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}