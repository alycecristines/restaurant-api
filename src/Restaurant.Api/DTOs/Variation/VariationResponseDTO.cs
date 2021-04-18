using System;
using Restaurant.Api.DTOs.Base;

namespace Restaurant.Api.DTOs.Variation
{
    public class VariationResponseDTO : ResponseDTO
    {
        public string Description { get; set; }
        public Guid ProductId { get; set; }
    }
}
