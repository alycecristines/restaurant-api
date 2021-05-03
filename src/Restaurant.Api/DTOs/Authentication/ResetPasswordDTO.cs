using System.ComponentModel.DataAnnotations;

namespace Restaurant.Api.DTOs.Authentication
{
    public class ResetPasswordDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
