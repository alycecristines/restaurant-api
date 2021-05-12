using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Localization;

namespace Restaurant.Domain.ValueObjects
{
    public class Address
    {
        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(100, ErrorMessage = PortugueseErrorDescriber.MaxStringLength)]
        public string Street { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(100, ErrorMessage = PortugueseErrorDescriber.MaxStringLength)]
        public string Secondary { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(4, MinimumLength = 1, ErrorMessage = PortugueseErrorDescriber.MinMaxStringLength)]
        public string BuildingNumber { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseErrorDescriber.MaxStringLength)]
        public string District { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseErrorDescriber.MaxStringLength)]
        public string City { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseErrorDescriber.MaxStringLength)]
        public string State { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseErrorDescriber.MaxStringLength)]
        public string Country { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(8, MinimumLength = 8, ErrorMessage = PortugueseErrorDescriber.FixedStringLength)]
        [RegularExpression(@"^\d*$", ErrorMessage = PortugueseErrorDescriber.Numeric)]
        public string ZipCode { get; set; }
    }
}
