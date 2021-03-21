using System.ComponentModel.DataAnnotations;
using Restaurant.Core.DTOs.Common;

namespace Restaurant.Core.DTOs.Request
{
    public class CompanyPostDTO
    {
        [Required, StringLength(150)]
        public string CorporateName { get; set; }

        [Required, StringLength(150)]
        public string BusinessName { get; set; }

        [Required, StringLength(14, MinimumLength = 14), RegularExpression(@"^\d*$")]
        public string RegistrationNumber { get; set; }

        [Required]
        public PhoneDTO Phone { get; set; }

        [Required]
        public AddressDTO Address { get; set; }
    }
}
