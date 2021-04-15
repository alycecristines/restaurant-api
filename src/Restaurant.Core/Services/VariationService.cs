using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Core.Interfaces;
using Restaurant.Core.QueryObjects;
using Restaurant.Core.Entities;
using Restaurant.Core.Exceptions;

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
                throw new CoreException("Não encontrado");
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
                throw new CoreException("Não encontrado");
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
                    entity.Description.Contains(filters.Description));
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
