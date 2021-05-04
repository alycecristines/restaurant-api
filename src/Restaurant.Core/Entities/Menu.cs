using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Localization;
using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enumerators;

namespace Restaurant.Core.Entities
{
    public class Menu : Entity
    {
        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MaxLength)]
        public string Description { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        public IEnumerable<Product> Products { get; set; }

        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        public DaysOfWeek Availability { get; set; }
    }
}
