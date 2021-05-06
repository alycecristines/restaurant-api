using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Localization;
using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Entities
{
    public class Department : Entity
    {
        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MaxStringLength)]
        public string Description { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
