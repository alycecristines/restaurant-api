using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.QueryFilters;

namespace Restaurant.Domain.Interfaces
{
    public interface IVariationDomainService
    {
        Task<Variation> CreateAsync(Variation newVariation);
        Task<Variation> UpdateAsync(Guid id, Variation newVariation);
        Task<IEnumerable<Variation>> FindAllAsync(VariationQueryFilter filters);
        Task<Variation> FindAsync(Guid id);
    }
}
