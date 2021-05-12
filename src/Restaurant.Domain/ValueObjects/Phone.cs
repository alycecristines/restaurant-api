using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Localization;

namespace Restaurant.Domain.ValueObjects
{
    public class Phone
    {
        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(2, MinimumLength = 2, ErrorMessage = PortugueseErrorDescriber.FixedStringLength)]
        [RegularExpression(@"^\d*$", ErrorMessage = PortugueseErrorDescriber.Numeric)]
        public string AreaCode { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(9, MinimumLength = 8, ErrorMessage = PortugueseErrorDescriber.MinMaxStringLength)]
        [RegularExpression(@"^\d*$", ErrorMessage = PortugueseErrorDescriber.Numeric)]
        public string Number { get; set; }
    }
}
