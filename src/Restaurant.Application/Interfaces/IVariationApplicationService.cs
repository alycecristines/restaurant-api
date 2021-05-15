using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Application.Models.Variation;
using Restaurant.Domain.QueryFilters;

namespace Restaurant.Application.Interfaces
{
    public interface IVariationApplicationService
    {
        Task<VariationResponseModel> CreateAsync(VariationCreateModel model);
        Task<VariationResponseModel> UpdateAsync(Guid id, VariationUpdateModel model);
        Task<IEnumerable<VariationResponseModel>> FindAllAsync(VariationQueryFilter filters);
        Task<VariationResponseModel> FindAsync(Guid id);
    }
}
