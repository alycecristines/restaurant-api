using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Localization;
using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Entities
{
    public class Product : Entity
    {
        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        [StringLength(50, ErrorMessage = PortugueseDataAnnotationErrorDescriber.MaxLength)]
        public string Description { get; set; }

        public IEnumerable<Variation> Variations { get; set; }

        public IEnumerable<Menu> Menus { get; set; }
    }
}
