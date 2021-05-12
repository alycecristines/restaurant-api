using System;
using System.Threading.Tasks;
using Restaurant.Application.Models.Order;
using Restaurant.Domain.QueryFilters;

namespace Restaurant.Application.Interfaces
{
    public interface IOrderApplicationService
    {
        Task<OrderResponseModel> CreateAsync(Guid employeeId, OrderCreateModel model);
        Task<OrderQueryResultModel> FindAllAsync(OrderQueryFilter filters);
    }
}
