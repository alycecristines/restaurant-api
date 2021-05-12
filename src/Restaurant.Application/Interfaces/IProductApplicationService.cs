using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Application.Models.Product;
using Restaurant.Domain.QueryFilters;

namespace Restaurant.Application.Interfaces
{
    public interface IProductApplicationService
    {
        Task<ProductResponseModel> CreateAsync(ProductCreateModel model);
        Task<ProductResponseModel> UpdateAsync(Guid id, ProductUpdateModel model);
        Task<IEnumerable<ProductResponseModel>> FindAllAsync(ProductQueryFilter filters);
        Task<ProductResponseModel> FindAsync(Guid id);
    }
}
