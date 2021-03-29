using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Common;
using Restaurant.Core.ValueObjects;

namespace Restaurant.Core.Entities
{
    public class Company : Entity
    {
        [Required]
        [StringLength(150)]
        public string CorporateName { get; set; }

        [Required]
        [StringLength(150)]
        public string BusinessName { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 14)]
        [RegularExpression(@"^\d*$")]
        public string RegistrationNumber { get; set; }

        [Required]
        public Phone Phone { get; set; }

        [Required]
        public Address Address { get; set; }

        public IEnumerable<Department> Departments { get; set; }
    }
}
