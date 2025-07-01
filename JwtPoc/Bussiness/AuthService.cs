using JwtPoc.JwtService;
using JwtPoc.Models;
using System.Security.Cryptography;

namespace JwtPoc.Bussiness
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(string userName, string Password);
        Task<UserData> GetUser();
    }
    public class AuthService : IAuthService
    {
        private readonly IJwtService _jwtService;
        public AuthService(IJwtService jwtService) 
        {
            _jwtService = jwtService;
        }
        public async Task<LoginResponse> Login(string userName, string Password)
        {
            LoginResponse resp;
            if (userName.Equals("admin@test.com") && Password.Equals("admin@123"))
            {
                resp = new LoginResponse();
                var token = await _jwtService.GenerateToken(userName);
                resp.token = token;
                resp.refresToken = await _jwtService.GenerateRefreshToken();

                return resp;
            }

            return null;
        }
        public async Task<UserData> GetUser()
        {  
            return new UserData{UserId = 10, UserName = "Admin", UserEmail = "admin@test.com" };
        }
    }
}
