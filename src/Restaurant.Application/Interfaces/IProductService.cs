using System;
using System.Collections.Generic;
using Restaurant.Application.DTOs.Product;
using Restaurant.Application.QueryParams;

namespace Restaurant.Application.Interfaces
{
    public interface IProductService
    {
        ProductResponseDTO Insert(ProductPostDTO dto);
        IEnumerable<ProductResponseDTO> GetAll(ProductQueryParams queryParams);
        ProductResponseDTO Get(Guid id);
        void Delete(Guid id);
    }
}