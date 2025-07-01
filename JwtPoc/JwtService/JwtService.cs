using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JwtPoc.JwtService
{
    public interface IJwtService
    {
        Task<string> GenerateToken(string userName);
        Task<string> GenerateRefreshToken();
    }
    public class JwtService : IJwtService
    {
        public async Task<string> GenerateToken(string userName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Your_Strong_Key_For_JWT123456789"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                    new Claim("user-name", userName)
                };

            var token = new JwtSecurityToken(
                issuer: "Your_Issue_Name",
                audience: "Your_Aud_Name",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10), // 10 mins of expiry
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<string> GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
    }
}
