using System;
using System.Threading.Tasks;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Models.Dashboard;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Application.Services
{
    public class DashboardApplicationService : IDashboardApplicationService
    {
        private readonly IOrderDomainService _orderService;

        public DashboardApplicationService(IOrderDomainService orderService)
        {
            _orderService = orderService;
        }

        public async Task<DashboardStatisticsResponseModel> GetStatistics(DateTime date)
        {
            return new DashboardStatisticsResponseModel
            {
                Orders = await GetOrderStatistics(date)
            };
        }

        private async Task<OrderStatisticsResponseModel> GetOrderStatistics(DateTime createdAt)
        {
            return new OrderStatisticsResponseModel
            {
                Total = await _orderService.Count(createdAt),
                TotalPrinted = await _orderService.CountPrinted(createdAt)
            };
        }
    }
}
