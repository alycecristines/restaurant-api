using System.Threading.Tasks;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.QueryFilters;
using System;
using AutoMapper;
using Restaurant.Application.Models.Order;

namespace Restaurant.Application.Services
{
    public class OrderApplicationService : IOrderApplicationService
    {
        private readonly IOrderDomainService _orderService;
        private readonly IEmployeeDomainService _employeeService;
        private readonly IMapper _mapper;

        public OrderApplicationService(IOrderDomainService orderService,
            IEmployeeDomainService employeeService, IMapper mapper)
        {
            _orderService = orderService;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public async Task<OrderResponseModel> CreateAsync(Guid employeeId, OrderCreateModel model)
        {
            var newOrder = _mapper.Map<Order>(model);
            newOrder.Employee = await _employeeService.FindAsync(employeeId);
            var createdOrder = await _orderService.CreateAsync(newOrder);
            return _mapper.Map<OrderResponseModel>(createdOrder);
        }

        public async Task<OrderQueryResultModel> FindAllAsync(OrderQueryFilter filters)
        {
            var orders = await _orderService.FindAllAsync(filters);
            return _mapper.Map<OrderQueryResultModel>(orders);
        }
    }
}
