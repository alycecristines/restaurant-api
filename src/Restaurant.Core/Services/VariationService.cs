using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Core.Services.Base;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;
using Restaurant.Core.Exceptions;
using Restaurant.Core.Repositories.Base;

namespace Restaurant.Core.Services
{
    public class VariationService : IVariationService
    {
        private readonly IRepository<Variation> _variationRepository;
        private readonly IRepository<Product> _productRepository;

        public Variation Create(Variation newVariation)
        {
            var existingProduct = _productRepository.Find(newVariation.ProductId);

            if (existingProduct == null)
            {
                throw new CoreException("The product was not found.");
            }

            _variationRepository.Add(newVariation);
            _variationRepository.SaveChanges();

            return newVariation;
        }

        public Variation Update(Guid id, Variation newVariation)
        {
            var currentVariation = _variationRepository.Find(id);

            if (currentVariation == null)
            {
                throw new CoreException("The variation was not found.");
            }

            currentVariation.Inactivated = newVariation.Inactivated;
            currentVariation.Description = newVariation.Description;
            currentVariation.UpdatedAt = DateTime.UtcNow;

            _variationRepository.SaveChanges();

            return currentVariation;
        }

        public IEnumerable<Variation> FindAll(VariationQueryFilter filters)
        {
            var queryable = _variationRepository.Queryable();

            if (!filters.IncludeInactivated)
            {
                queryable = queryable.Where(company => !company.Inactivated);
            }

            if (!string.IsNullOrWhiteSpace(filters.Description))
            {
                queryable = queryable.Where(entity =>
                    entity.Description.ToLower().Contains(filters.Description.ToLower()));
            }

            if (filters.ProductId.HasValue)
            {
                queryable = queryable.Where(entity => entity.ProductId == filters.ProductId);
            }

            return queryable.ToList();
        }

        public Variation Find(Guid id)
        {
            return _variationRepository.Find(id);
        }
    }
}
