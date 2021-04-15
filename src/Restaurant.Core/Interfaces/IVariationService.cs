using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;

namespace Restaurant.Core.Interfaces
{
    public interface IVariationService : IService<Variation, VariationQueryFilter>
    {
    }
}
