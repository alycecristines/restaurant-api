using System;
using System.Threading.Tasks;
using Restaurant.Application.Models.Dashboard;

namespace Restaurant.Application.Interfaces
{
    public interface IDashboardApplicationService
    {
        Task<DashboardStatisticsResponseModel> GetStatistics(DateTime date);
    }
}
