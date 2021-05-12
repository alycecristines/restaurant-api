using System;
using System.Collections.Generic;
using Restaurant.Domain.QueryFilters;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Extensions;

namespace Restaurant.Domain.Services
{
    public class VariationDomainService : IVariationDomainService
    {
        private readonly IRepository<Variation> _variationRepository;

        public VariationDomainService(IRepository<Variation> variationRepository)
        {
            _variationRepository = variationRepository;
        }

        public async Task<Variation> CreateAsync(Variation newVariation)
        {
            _variationRepository.Add(newVariation);
            await _variationRepository.SaveChangesAsync();
            return newVariation;
        }

        public async Task<Variation> UpdateAsync(Guid id, Variation newVariation)
        {
            var currentVariation = await _variationRepository.FindAsync(id);

            currentVariation.Inactivated = newVariation.Inactivated;
            currentVariation.Description = newVariation.Description;
            currentVariation.UpdatedAt = DateTime.UtcNow;

            await _variationRepository.SaveChangesAsync();
            return currentVariation;
        }

        public async Task<IEnumerable<Variation>> FindAllAsync(VariationQueryFilter filters)
        {
            return await _variationRepository.Queryable()
                .WhereFor(!filters.IncludeInactivated, variation => !variation.Inactivated)
                .WhereFor(filters.Description, variation => EF.Functions.Like(variation.Description, $"%{filters.Description}%"))
                .WhereFor(filters.ProductId, variation => variation.ProductId == filters.ProductId)
                .ToListAsync();
        }

        public async Task<Variation> FindAsync(Guid id)
        {
            return await _variationRepository.FindAsync(id);
        }
    }
}
