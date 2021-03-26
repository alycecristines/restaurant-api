using System;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Common;

namespace Restaurant.Core.Entities
{
    public class Employee : Entity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; private set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; private set; }

        [Required]
        public Guid DepartmentId { get; private set; }
        public Department Department { get; private set; }
    }
}
