using System;
using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Localization;

namespace Restaurant.Domain.ValueObjects
{
    public class OrderItem
    {
        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        public Guid OrderId { get; set; }

        public Order Order { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        public Guid VariationId { get; set; }

        public Variation Variation { get; set; }
    }
}
