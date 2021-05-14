using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.QueryFilters;
using Restaurant.Domain.QueryResults;

namespace Restaurant.Domain.Interfaces
{
    public interface IOrderDomainService
    {
        Task<Order> CreateAsync(Order newOrder);
        Task<OrderQueryResult> FindAllAsync(OrderQueryFilter filters);
        Task<OrderQueryResult> PrintAllAsync(OrderQueryFilter filters);
    }
}
