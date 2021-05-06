using System;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Entities;
using Restaurant.Core.Localization;

namespace Restaurant.Core.ValueObjects
{
    public class OrderItem
    {
        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        public Guid OrderId { get; set; }

        public Order Order { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        public Guid VariationId { get; set; }

        public Variation Variation { get; set; }
    }
}
