using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Order;
using Restaurant.Api.Extensions;
using Restaurant.Api.Wrappers;
using Restaurant.Core.Entities;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Services.Base;
using Restaurant.Infrastructure.Identity.Constants;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    [Authorize(Roles = RoleConstants.Employee)]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IEmployeeService employeeService, IMapper mapper)
        {
            _orderService = orderService;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderPostDTO dto)
        {
            var newEntity = _mapper.Map<Order>(dto);
            newEntity.Employee = await _employeeService.FindAsync(User.GetId());
            var insertedEntity = await _orderService.CreateAsync(newEntity);
            var insertedEntityDto = _mapper.Map<OrderResponseDTO>(insertedEntity);
            var response = new Response(insertedEntityDto);
            var getParams = new { insertedEntityDto.Id };
            var getActionName = nameof(Get);

            return CreatedAtAction(getActionName, getParams, response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] OrderQueryFilter filters)
        {
            var entities = await _orderService.FindAllAsync(filters);
            var entitiesDto = _mapper.Map<IEnumerable<OrderResponseDTO>>(entities);
            var response = new Response(entitiesDto);

            return Ok(response);
        }
    }
}
