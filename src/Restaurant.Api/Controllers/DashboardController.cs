using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.Wrappers;
using Restaurant.Application.Interfaces;
using Restaurant.Infrastructure.Identity.Constants;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    [Authorize(Roles = RoleConstants.Administrator)]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardApplicationService _dashboardService;

        public DashboardController(IDashboardApplicationService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("{date:datetime}")]
        public async Task<IActionResult> Get(DateTime date)
        {
            var statistics = await _dashboardService.GetStatistics(date);
            var response = new Response(statistics);
            return Ok(response);
        }
    }
}
