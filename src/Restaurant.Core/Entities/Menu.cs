using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enumerators;

namespace Restaurant.Core.Entities
{
    public class Menu : Entity
    {
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        public IEnumerable<Product> Products { get; set; }

        [Required]
        public DaysOfWeek Availability { get; set; }
    }
}
