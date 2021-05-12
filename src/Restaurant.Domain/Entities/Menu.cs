using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Localization;
using Restaurant.Domain.Entities.Base;
using Restaurant.Domain.Enumerators;

namespace Restaurant.Domain.Entities
{
    public class Menu : Entity
    {
        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseErrorDescriber.MaxStringLength)]
        public string Description { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [MinLength(1, ErrorMessage = PortugueseErrorDescriber.MinCollectionLength)]
        public IList<Product> Products { get; set; }

        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        public DaysOfWeek Availability { get; set; }
    }
}
