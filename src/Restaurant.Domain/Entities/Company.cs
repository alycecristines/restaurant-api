using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Localization;
using Restaurant.Domain.Entities.Base;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Domain.Entities
{
    public class Company : Entity
    {
        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(150, ErrorMessage = PortugueseErrorDescriber.MaxStringLength)]
        public string CorporateName { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(150, ErrorMessage = PortugueseErrorDescriber.MaxStringLength)]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(14, MinimumLength = 14, ErrorMessage = PortugueseErrorDescriber.FixedStringLength)]
        [RegularExpression(@"^\d*$", ErrorMessage = PortugueseErrorDescriber.Numeric)]
        public string RegistrationNumber { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        public Phone Phone { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        public Address Address { get; set; }

        public IEnumerable<Department> Departments { get; set; }
    }
}
