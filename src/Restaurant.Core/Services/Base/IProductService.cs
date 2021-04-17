using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;

namespace Restaurant.Core.Services.Base
{
    public interface IProductService : IService<Product, ProductQueryFilter>
    {
    }
}
