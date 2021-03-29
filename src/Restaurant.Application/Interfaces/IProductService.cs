using Restaurant.Application.DTOs.Product;

namespace Restaurant.Application.Interfaces
{
    public interface IProductService
    {
        ProductResponseDTO Insert(ProductPostDTO dto);
    }
}
