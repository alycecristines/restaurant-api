using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Core.Services.Base;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateAsync(Product newProduct)
        {
            _productRepository.Add(newProduct);

            await _productRepository.SaveChangesAsync();

            return newProduct;
        }

        public async Task<Product> UpdateAsync(Guid id, Product newProduct)
        {
            var currentProduct = await _productRepository.FindAsync(id);

            currentProduct.Inactivated = newProduct.Inactivated;
            currentProduct.Description = newProduct.Description;
            currentProduct.UpdatedAt = DateTime.UtcNow;

            await _productRepository.SaveChangesAsync();

            return currentProduct;
        }

        public async Task<IEnumerable<Product>> FindAllAsync(ProductQueryFilter filters)
        {
            var queryable = _productRepository.Queryable();

            if (!filters.IncludeInactivated)
            {
                queryable = queryable.Where(product =>
                    !product.Inactivated);
            }

            if (!string.IsNullOrWhiteSpace(filters.Description))
            {
                queryable = queryable.Where(product =>
                    EF.Functions.Like(product.Description, $"%{filters.Description}%"));
            }

            if (filters.MenuId.HasValue)
            {
                queryable = queryable.Where(product =>
                    product.Menus.Any(menu => menu.Id == filters.MenuId));
            }

            return await queryable.ToListAsync();
        }

        public async Task<Product> FindAsync(Guid id)
        {
            return await _productRepository.FindAsync(id);
        }
    }
}
