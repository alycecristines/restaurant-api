using System;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Entities
{
    public class Employee : Entity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
