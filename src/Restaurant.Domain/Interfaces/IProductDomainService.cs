using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.QueryFilters;

namespace Restaurant.Domain.Interfaces
{
    public interface IProductDomainService
    {
        Task<Product> CreateAsync(Product newProduct);
        Task<Product> UpdateAsync(Guid id, Product newProduct);
        Task<IEnumerable<Product>> FindAllAsync(ProductQueryFilter filters);
        Task<Product> FindAsync(Guid id);
    }
}
