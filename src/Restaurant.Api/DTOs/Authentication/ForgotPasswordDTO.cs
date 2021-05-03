using System.ComponentModel.DataAnnotations;

namespace Restaurant.Api.DTOs.Authentication
{
    public class ForgotPasswordDTO
    {
        [Required]
        public string UserName { get; set; }
    }
}
