using Restaurant.Application.Models.Product;
using Restaurant.Application.Models.Variation;

namespace Restaurant.Application.Models.Order
{
    public class OrderItemResponseModel
    {
        public ProductResponseModel Product { get; set; }
        public VariationResponseModel Variation { get; set; }
    }
}
