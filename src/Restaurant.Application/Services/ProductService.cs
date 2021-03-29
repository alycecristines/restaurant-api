using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Application.Extensions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;

namespace Restaurant.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IServiceValidator _validator;

        public ProductService(IRepository<Product> repository, IServiceValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public Product Insert(Product newProduct)
        {
            _repository.Insert(newProduct);
            _repository.SaveChanges();

            return newProduct;
        }

        public IEnumerable<Product> GetAll(ProductQueryParams queryParams)
        {
            var query = _repository.GetAll(queryParams.IncludeInactive);

            if (!string.IsNullOrWhiteSpace(queryParams.Description))
            {
                query = query.Where(entity =>
                    entity.Description.ContainsResearch(queryParams.Description));
            }

            return query.ToList();
        }

        public Product Get(Guid id)
        {
            var product = _repository.Get(id);

            _validator.Found(product);

            return product;
        }

        public Product Update(Guid id, Product newProduct)
        {
            var currentProduct = _repository.Get(id);

            _validator.Found(currentProduct);
            _validator.NotDeleted(currentProduct);

            currentProduct.Description = newProduct.Description;
            currentProduct.Update(DateTime.UtcNow);

            _repository.SaveChanges();

            return currentProduct;
        }

        public void Delete(Guid id)
        {
            var product = _repository.Get(id);

            _validator.Found(product);
            _validator.NotDeleted(product);

            product.Delete(DateTime.UtcNow);

            _repository.SaveChanges();
        }
    }
}
