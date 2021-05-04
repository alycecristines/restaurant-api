using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Localization;

namespace Restaurant.Core.ValueObjects
{
    public class Address
    {
        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(100, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MaxLength)]
        public string Street { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(100, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MaxLength)]
        public string Secondary { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(4, MinimumLength = 1, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MinMaxLength)]
        public string BuildingNumber { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MaxLength)]
        public string District { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MaxLength)]
        public string City { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MaxLength)]
        public string State { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MaxLength)]
        public string Country { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(8, MinimumLength = 8, ErrorMessage = PortugueseDataAnnotationErrorDescriber.FixedLength)]
        [RegularExpression(@"^\d*$", ErrorMessage = PortugueseDataAnnotationErrorDescriber.Numeric)]
        public string ZipCode { get; set; }
    }
}
