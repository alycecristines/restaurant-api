using System;

namespace Restaurant.Api.DTOs.Product
{
    public class ProductResponseDTO
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactivated { get; set; }
        public string Description { get; set; }
    }
}
