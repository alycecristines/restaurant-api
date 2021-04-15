using Restaurant.Core.QueryObjects;
using Restaurant.Core.Entities;

namespace Restaurant.Core.Interfaces
{
    public interface IProductService : IService<Product, ProductQueryFilter>
    {
    }
}
