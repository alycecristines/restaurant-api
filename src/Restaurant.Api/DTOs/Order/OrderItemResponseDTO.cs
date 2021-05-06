using Restaurant.Api.DTOs.Product;
using Restaurant.Api.DTOs.Variation;

namespace Restaurant.Api.DTOs.Order
{
    public class OrderItemResponseDTO
    {
        public ProductResponseDTO Product { get; set; }
        public VariationResponseDTO Variation { get; set; }
    }
}
