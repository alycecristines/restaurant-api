using System;
using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Localization;
using Restaurant.Domain.Entities.Base;

namespace Restaurant.Domain.Entities
{
    public class Variation : Entity
    {
        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseErrorDescriber.MaxStringLength)]
        public string Description { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        public Guid ProductId { get; set; }

        public Product Product { get; set; }
    }
}
