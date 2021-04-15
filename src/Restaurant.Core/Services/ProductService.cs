using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Core.Interfaces;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;
using Restaurant.Core.Exceptions;

namespace Restaurant.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Create(Product newProduct)
        {
            _productRepository.Add(newProduct);
            _productRepository.SaveChanges();

            return newProduct;
        }

        public Product Update(Guid id, Product newProduct)
        {
            var currentProduct = _productRepository.Find(id);

            if (currentProduct == null)
            {
                throw new CoreException("The product was not found.");
            }

            currentProduct.Inactivated = newProduct.Inactivated;
            currentProduct.Description = newProduct.Description;
            currentProduct.UpdatedAt = DateTime.UtcNow;

            _productRepository.SaveChanges();

            return currentProduct;
        }

        public IEnumerable<Product> FindAll(ProductQueryFilter filters)
        {
            var queryable = _productRepository.Queryable();

            if (!filters.IncludeInactivated)
            {
                queryable = queryable.Where(company => !company.Inactivated);
            }

            if (!string.IsNullOrWhiteSpace(filters.Description))
            {
                queryable = queryable.Where(entity =>
                    entity.Description.Contains(filters.Description));
            }

            return queryable.ToList();
        }

        public Product Find(Guid id)
        {
            return _productRepository.Find(id);
        }
    }
}
