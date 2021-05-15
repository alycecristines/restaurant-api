using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Domain.QueryFilters;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Extensions;

namespace Restaurant.Domain.Services
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductDomainService(IRepository<Product> productRepository)
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
            return await _productRepository.Queryable()
                .WhereFor(!filters.IncludeInactivated, product => !product.Inactivated)
                .WhereFor(filters.Description, product => EF.Functions.Like(product.Description, $"%{filters.Description}%"))
                .WhereFor(filters.MenuId, product => product.Menus.Any(menu => menu.Id == filters.MenuId))
                .ToListAsync();
        }

        public async Task<Product> FindAsync(Guid id)
        {
            return await _productRepository.FindAsync(id);
        }
    }
}
