using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Common;

namespace Restaurant.Core.Entities
{
    public class Department : Entity
    {
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
