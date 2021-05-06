using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Repositories.Base;
using Restaurant.Core.Services.Base;
using Restaurant.Core.ValueObjects;

namespace Restaurant.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Variation> _variationRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<Product> productRepository, IRepository<Variation> variationRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _variationRepository = variationRepository;
        }

        public async Task<Order> CreateAsync(Order newEntity)
        {
            newEntity.Items = await GetItems(newEntity.Items);

            _orderRepository.Add(newEntity);

            await _orderRepository.SaveChangesAsync();

            return newEntity;
        }

        private async Task<IEnumerable<OrderItem>> GetItems(IEnumerable<OrderItem> orderItems)
        {
            var validatedOrderItems = new List<OrderItem>();

            foreach (var orderItem in orderItems)
            {
                var product = await _productRepository.FindAsync(orderItem.Product.Id);
                var variation = await _variationRepository.FindAsync(orderItem.Variation.Id);
                var validatedOrderItem = new OrderItem { Product = product, Variation = variation };
                validatedOrderItems.Add(validatedOrderItem);
            }

            return validatedOrderItems;
        }

        public async Task<IEnumerable<Order>> FindAllAsync(OrderQueryFilter filters)
        {
            var queryable = _orderRepository.Queryable();

            if (!filters.IncludeInactivated)
            {
                queryable = queryable.Where(order =>
                    !order.Inactivated);
            }

            return await queryable.Where(order => order.CreatedAt.Date == filters.CreatedAt.Date)
                .Include(order => order.Employee)
                    .ThenInclude(employee => employee.Department)
                        .ThenInclude(department => department.Company)
                .Include(order => order.Items)
                    .ThenInclude(item => item.Product)
                .Include(order => order.Items)
                    .ThenInclude(item => item.Variation)
                .ToListAsync();
        }

        public async Task<Order> FindAsync(Guid id)
        {
            return await _orderRepository.FindAsync(id);
        }
    }
}
