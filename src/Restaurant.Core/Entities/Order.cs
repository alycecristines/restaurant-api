using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Entities.Base;
using Restaurant.Core.Localization;
using Restaurant.Core.ValueObjects;

namespace Restaurant.Core.Entities
{
    public class Order : Entity
    {
        public bool Printed { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [MinLength(1, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MinCollectionLength)]
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
