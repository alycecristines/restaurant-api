using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Models.Order;
using Restaurant.Api.Wrappers;
using Restaurant.Domain.QueryFilters;
using Restaurant.Infrastructure.Identity.Constants;
using Restaurant.Application.Interfaces;
using Restaurant.Api.Extensions;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderApplicationService _orderService;

        public OrderController(IOrderApplicationService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.Employee)]
        public async Task<IActionResult> Post(OrderCreateModel model)
        {
            var createdOrder = await _orderService.CreateAsync(User.GetId(), model);
            var response = new Response(createdOrder);
            var getParams = new { createdOrder.Id };
            return CreatedAtAction(nameof(Get), getParams, response);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.Administrator)]
        public async Task<IActionResult> Get([FromQuery] OrderQueryFilter filters)
        {
            var orders = await _orderService.FindAllAsync(filters);
            var response = new Response(orders);
            return Ok(response);
        }
    }
}
