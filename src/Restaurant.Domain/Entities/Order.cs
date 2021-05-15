using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Entities.Base;
using Restaurant.Domain.Localization;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Domain.Entities
{
    public class Order : Entity
    {
        public bool Printed { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [MinLength(1, ErrorMessage = PortugueseErrorDescriber.MinCollectionLength)]
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
