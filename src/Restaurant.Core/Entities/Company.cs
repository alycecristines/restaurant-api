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
        public string CorporateName { get; private set; }

        [Required]
        [StringLength(150)]
        public string BusinessName { get; private set; }

        [Required]
        [StringLength(14, MinimumLength = 14)]
        [RegularExpression(@"^\d*$")]
        public string RegistrationNumber { get; private set; }

        [Required]
        public Phone Phone { get; private set; }

        [Required]
        public Address Address { get; private set; }

        public IEnumerable<Department> Departments { get; private set; }
    }
}
