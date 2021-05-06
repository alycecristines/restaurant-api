using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Localization;

namespace Restaurant.Core.ValueObjects
{
    public class Phone
    {
        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(2, MinimumLength = 2, ErrorMessage = PortugueseDataAnnotationErrorDescriber.FixedStringLength)]
        [RegularExpression(@"^\d*$", ErrorMessage = PortugueseDataAnnotationErrorDescriber.Numeric)]
        public string AreaCode { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(9, MinimumLength = 8, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MinMaxStringLength)]
        [RegularExpression(@"^\d*$", ErrorMessage = PortugueseDataAnnotationErrorDescriber.Numeric)]
        public string Number { get; set; }
    }
}
