using System.ComponentModel.DataAnnotations;

namespace JwtPoc.Models
{
    public class AuthDto
    {
    }
    public class LoginRequest
    {
        [Required]
        [MaxLength(150)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class LoginResponse
    {
        public string token { get; set; }
        public string refresToken { get; set; }
        public long expiresIn { get; set; }
    }
    public class UserData
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
    }
}
