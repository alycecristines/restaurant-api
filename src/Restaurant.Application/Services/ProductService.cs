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
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Variation> _variationRepository;
        private readonly IServiceValidator _validator;

        public ProductService(IRepository<Product> productRepository,
            IRepository<Variation> variationRepository, IServiceValidator validator)
        {
            _productRepository = productRepository;
            _variationRepository = variationRepository;
            _validator = validator;
        }

        public Product Insert(Product newProduct)
        {
            _productRepository.Insert(newProduct);
            _productRepository.SaveChanges();

            return newProduct;
        }

        public IEnumerable<Product> GetAll(ProductQueryParams queryParams)
        {
            var query = _productRepository.GetAll(queryParams.IncludeInactive);

            if (!string.IsNullOrWhiteSpace(queryParams.Description))
            {
                query = query.Where(entity =>
                    entity.Description.ContainsResearch(queryParams.Description));
            }

            return query.ToList();
        }

        public Product Get(Guid id)
        {
            var product = _productRepository.Get(id);

            _validator.Found(product);

            return product;
        }

        public Product Update(Guid id, Product newProduct)
        {
            var currentProduct = _productRepository.Get(id);

            _validator.Found(currentProduct);
            _validator.NotDeleted(currentProduct);

            currentProduct.Description = newProduct.Description;
            currentProduct.Update(DateTime.UtcNow);

            _productRepository.SaveChanges();

            return currentProduct;
        }

        public void Delete(Guid id)
        {
            var product = _productRepository.Get(id);

            _validator.Found(product);
            _validator.NotDeleted(product);

            var relatedVariation = _variationRepository.GetAll()
                .FirstOrDefault(entity => entity.ProductId == id);

            _validator.HasNoRelated(relatedVariation);

            product.Delete(DateTime.UtcNow);

            _productRepository.SaveChanges();
        }
    }
}
