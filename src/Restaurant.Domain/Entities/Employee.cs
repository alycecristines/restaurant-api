using System;
using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Localization;
using Restaurant.Domain.Entities.Base;
using System.Collections.Generic;

namespace Restaurant.Domain.Entities
{
    public class Employee : User
    {
        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
