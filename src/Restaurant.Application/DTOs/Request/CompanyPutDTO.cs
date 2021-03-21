using System;
using System.ComponentModel.DataAnnotations;
using Restaurant.Application.DTOs.Common;

namespace Restaurant.Application.DTOs.Request
{
    public class CompanyPutDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required, StringLength(150)]
        public string CorporateName { get; set; }

        [Required, StringLength(150)]
        public string BusinessName { get; set; }

        [Required]
        public PhoneDTO Phone { get; set; }

        [Required]
        public AddressDTO Address { get; set; }
    }
}
