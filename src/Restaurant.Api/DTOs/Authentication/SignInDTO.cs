using System.ComponentModel.DataAnnotations;

namespace Restaurant.Api.DTOs.Authentication
{
    public class SignInDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
