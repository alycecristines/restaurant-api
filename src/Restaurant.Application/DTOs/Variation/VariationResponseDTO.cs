using System;

namespace Restaurant.Application.DTOs.Variation
{
    public class VariationResponseDTO
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public string Description { get; set; }
        public Guid ProductId { get; set; }
    }
}
