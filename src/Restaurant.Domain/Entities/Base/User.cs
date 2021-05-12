using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Localization;

namespace Restaurant.Domain.Entities.Base
{
    public class User : Entity
    {
        public string UserName => Email;

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(100, ErrorMessage = PortugueseErrorDescriber.MaxStringLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [EmailAddress(ErrorMessage = PortugueseErrorDescriber.Email)]
        [StringLength(100, ErrorMessage = PortugueseErrorDescriber.MaxStringLength)]
        public string Email { get; set; }

        public bool CanAccessTheSystem()
        {
            return !Inactivated;
        }
    }
}
