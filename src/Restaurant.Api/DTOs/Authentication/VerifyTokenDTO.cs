using System.ComponentModel.DataAnnotations;

namespace Restaurant.Api.DTOs.Authentication
{
    public class VerifyTokenDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
