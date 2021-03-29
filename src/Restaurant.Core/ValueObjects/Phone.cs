using System.ComponentModel.DataAnnotations;

namespace Restaurant.Core.ValueObjects
{
    public class Phone
    {
        [Required]
        [StringLength(2, MinimumLength = 2)]
        [RegularExpression(@"^\d*$")]
        public string AreaCode { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 8)]
        [RegularExpression(@"^\d*$")]
        public string Number { get; set; }
    }
}
