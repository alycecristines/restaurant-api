using System;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Localization;
using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Entities
{
    public class Variation : Entity
    {
        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MaxLength)]
        public string Description { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        public Guid ProductId { get; set; }

        public Product Product { get; set; }
    }
}
