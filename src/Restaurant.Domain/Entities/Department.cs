using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Localization;
using Restaurant.Domain.Entities.Base;

namespace Restaurant.Domain.Entities
{
    public class Department : ActivableEntity
    {
        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseErrorDescriber.MaxStringLength)]
        public string Description { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
