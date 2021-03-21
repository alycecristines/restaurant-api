using System.ComponentModel.DataAnnotations;

namespace Restaurant.Core.DTOs.Common
{
    public class AddressDTO
    {
        [Required, MaxLength(100)]
        public string Street { get; set; }

        [Required, MaxLength(100)]
        public string Secondary { get; set; }

        [Required, StringLength(4, MinimumLength = 1)]
        public string BuildingNumber { get; set; }

        [Required, MaxLength(50)]
        public string District { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(50)]
        public string State { get; set; }

        [Required, MaxLength(50)]
        public string Country { get; set; }

        [Required, StringLength(8, MinimumLength = 8)]
        public string ZipCode { get; set; }
    }
}
