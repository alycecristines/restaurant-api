using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Localization;
using Restaurant.Domain.Entities.Base;

namespace Restaurant.Domain.Entities
{
    public class Product : ActivableEntity
    {
        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseErrorDescriber.MaxStringLength)]
        public string Description { get; set; }

        public IEnumerable<Variation> Variations { get; set; }

        public IEnumerable<Menu> Menus { get; set; }
    }
}
