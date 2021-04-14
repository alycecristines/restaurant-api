using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Application.Extensions;
using Restaurant.Application.Interfaces;
using Restaurant.Core.QueryObjects;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;

namespace Restaurant.Application.Services
{
    public class VariationService : IVariationService
    {
        private readonly IRepository<Variation> _variationRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IServiceValidator _validator;

        public VariationService(IRepository<Variation> variationRepository,
            IRepository<Product> productRepository, IServiceValidator validator)
        {
            _variationRepository = variationRepository;
            _productRepository = productRepository;
            _validator = validator;
        }

        public Variation Insert(Variation newVariation)
        {
            var existingProduct = _productRepository.Get(newVariation.ProductId);

            _validator.Found(existingProduct);
            _validator.NotDeleted(existingProduct);

            _variationRepository.Insert(newVariation);
            _variationRepository.SaveChanges();

            return newVariation;
        }

        public IEnumerable<Variation> GetAll(VariationQuery queryParams)
        {
            var query = _variationRepository.GetAll(queryParams.IncludeDeleted, queryParams.IncludeInactivated);

            if (!string.IsNullOrWhiteSpace(queryParams.Description))
            {
                query = query.Where(entity =>
                    entity.Description.ContainsResearch(queryParams.Description));
            }

            if (queryParams.ProductId.HasValue)
            {
                query = query.Where(entity => entity.ProductId == queryParams.ProductId);
            }

            return query.ToList();
        }

        public Variation Get(Guid id)
        {
            var variation = _variationRepository.Get(id);

            _validator.Found(variation);

            return variation;
        }

        public Variation Update(Guid id, Variation newVariation)
        {
            var currentVariation = _variationRepository.Get(id);

            _validator.Found(currentVariation);
            _validator.NotDeleted(currentVariation);

            currentVariation.Inactivated = newVariation.Inactivated;
            currentVariation.Description = newVariation.Description;
            currentVariation.Update(DateTime.UtcNow);

            _variationRepository.SaveChanges();

            return currentVariation;
        }

        public void Delete(Guid id)
        {
            var variation = _variationRepository.Get(id);

            _validator.Found(variation);
            _validator.NotDeleted(variation);

            variation.Delete(DateTime.UtcNow);

            _variationRepository.SaveChanges();
        }
    }
}
