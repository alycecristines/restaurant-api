using System;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Entities
{
    public class Variation : Entity
    {
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
