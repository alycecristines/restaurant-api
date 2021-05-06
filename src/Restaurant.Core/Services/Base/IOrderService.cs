using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Core.Entities;
using Restaurant.Core.QueryFilters;

namespace Restaurant.Core.Services.Base
{
    public interface IOrderService
    {
        Task<Order> CreateAsync(Order newEntity);
        Task<IEnumerable<Order>> FindAllAsync(OrderQueryFilter filters);
    }
}
