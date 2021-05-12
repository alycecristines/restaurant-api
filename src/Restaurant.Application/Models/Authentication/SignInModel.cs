using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Localization;

namespace Restaurant.Application.Models.Authentication
{
    public class SignInModel
    {
        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        public string UserName { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        public string Password { get; set; }
    }
}
