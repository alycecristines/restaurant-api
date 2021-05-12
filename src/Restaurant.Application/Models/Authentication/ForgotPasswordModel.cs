using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Localization;

namespace Restaurant.Application.Models.Authentication
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        public string UserName { get; set; }
    }
}
