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
    public class VariationService : IVariationService
    {
        private readonly IRepository<Variation> _variationRepository;

        public VariationService(IRepository<Variation> variationRepository)
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
            var queryable = _variationRepository.Queryable();

            if (!filters.IncludeInactivated)
            {
                queryable = queryable.Where(menu =>
                    !menu.Inactivated);
            }

            if (!string.IsNullOrWhiteSpace(filters.Description))
            {
                queryable = queryable.Where(menu =>
                    EF.Functions.Like(menu.Description, $"%{filters.Description}%"));
            }

            if (filters.ProductId.HasValue)
            {
                queryable = queryable.Where(menu =>
                    menu.ProductId == filters.ProductId);
            }

            return await queryable.ToListAsync();
        }

        public async Task<Variation> FindAsync(Guid id)
        {
            return await _variationRepository.FindAsync(id);
        }
    }
}
