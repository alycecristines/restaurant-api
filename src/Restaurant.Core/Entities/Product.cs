using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Common;

namespace Restaurant.Core.Entities
{
    public class Product : Entity
    {
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public IEnumerable<Variation> Variations { get; set; }
    }
}
