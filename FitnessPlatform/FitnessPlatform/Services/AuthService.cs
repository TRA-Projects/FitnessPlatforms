using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitnessPlatform.Services
{
    public class AuthService
    {
        // Read JWT settings from appsettings.json
        private readonly IConfiguration _configuration;

        // Constructor to inject configuration settings
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Generate JWT token for authenticated user
        public string GenerateToken(
            int userId,
            string username,
            string role)
        {
            // Add user information as claims inside the token
            var claims = new[]
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    userId.ToString()),

                new Claim(
                    ClaimTypes.Name,
                    username),

                new Claim(
                    ClaimTypes.Role,//admin ,trainer
                    role)
            };


            var key = new SymmetricSecurityKey(  //أنشأنا مفتاح تشفير
                Encoding.UTF8.GetBytes(
                _configuration["JwtSettings:SecretKey"]!)
            );

            // Create signing credentials using HmacSha256 algorithm
            var credentials = new SigningCredentials(
                key,  //المفتاح الذي سيستخدم للتوقيع
                SecurityAlgorithms.HmacSha256  //خوارزمية التشفير المستخدمة.
            );


            var token = new JwtSecurityToken(

                issuer:
                _configuration["JwtSettings:Issuer"],

                audience://من هو المسموح له باستخدام هذا التوكن
                _configuration["JwtSettings:Audience"],

                claims: claims,//المعلومات التي ستوضع داخل التوكن.

                expires:
                DateTime.Now.AddHours(
                Convert.ToDouble(
                _configuration["JwtSettings:ExpiryHours"])),

                signingCredentials: credentials //استخدام بيانات التوقيع التي أنشأناها
            );

            // Convert JWT token to string and return it
            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}