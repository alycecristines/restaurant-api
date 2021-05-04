using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Localization;
using Restaurant.Core.Entities.Base;
using Restaurant.Core.ValueObjects;

namespace Restaurant.Core.Entities
{
    public class Company : Entity
    {
        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(150, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MaxLength)]
        public string CorporateName { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(150, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MaxLength)]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(14, MinimumLength = 14, ErrorMessage = PortugueseDataAnnotationErrorDescriber.FixedLength)]
        [RegularExpression(@"^\d*$", ErrorMessage = PortugueseDataAnnotationErrorDescriber.Numeric)]
        public string RegistrationNumber { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        public Phone Phone { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        public Address Address { get; set; }

        public IEnumerable<Department> Departments { get; set; }
    }
}
