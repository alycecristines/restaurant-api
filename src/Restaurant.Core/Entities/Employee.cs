using System;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Localization;
using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Entities
{
    public class Employee : Entity
    {
        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(100, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MaxLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [EmailAddress(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Email)]
        [StringLength(100, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MaxLength)]
        public string Email { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
