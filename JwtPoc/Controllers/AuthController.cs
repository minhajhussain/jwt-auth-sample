using JwtPoc.Bussiness;
using JwtPoc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtPoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")] // => This method will be excempted from Authorization
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var data = await _authService.Login(request.UserName,request.Password);

            return Ok(data);
        }
        [HttpGet("user")] // => As AllowAnonymous is not applied Authorization is enforeced to this method
        public async Task<IActionResult> User()
        {
            var data = await _authService.GetUser();

            return Ok(data);
        }
    }
}
