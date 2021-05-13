using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Extensions;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.QueryFilters;
using Restaurant.Domain.QueryResults;
using Restaurant.Domain.Repositories.Base;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Domain.Services
{
    public class OrderDomainService : IOrderDomainService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;

        public OrderDomainService(IRepository<Order> orderRepository,
            IRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<Order> CreateAsync(Order newOrder)
        {
            await ValidateCreationAsync(newOrder);
            newOrder.Items = await GetItems(newOrder.Items);
            _orderRepository.Add(newOrder);
            await _orderRepository.SaveChangesAsync();
            return newOrder;
        }

        private async Task ValidateCreationAsync(Order newOrder)
        {
            if (await ExistsForTheDay(newOrder.CreatedAt))
            {
                var message = $"Já existe um pedidos realizado para o dia '{newOrder.CreatedAt.Date}'.";
                throw new DomainException(message);
            }
        }

        private async Task<bool> ExistsForTheDay(DateTime date)
        {
            return await _orderRepository.Queryable().AnyAsync(order => order.CreatedAt.Date == date.Date);
        }

        private async Task<IEnumerable<OrderItem>> GetItems(IEnumerable<OrderItem> orderItems)
        {
            var validatedOrderItems = new List<OrderItem>();

            foreach (var orderItem in orderItems)
            {
                var itemProduct = await _productRepository.Queryable().Include(product => product.Variations)
                    .FirstOrDefaultAsync(product => product.Id == orderItem.Product.Id);

                var itemVariation = itemProduct.Variations.FirstOrDefault(variation => variation.Id == orderItem.Variation.Id);
                var validatedOrderItem = new OrderItem { Product = itemProduct, Variation = itemVariation };
                validatedOrderItems.Add(validatedOrderItem);
            }

            return validatedOrderItems;
        }

        public async Task<OrderQueryResult> FindAllAsync(OrderQueryFilter filters)
        {
            var orders = await _orderRepository.Queryable()
                .Where(order => order.CreatedAt.Date == filters.CreatedAt.Date)
                .WhereFor(filters.CompanyId, order => order.Employee.Department.Company.Id == filters.CompanyId)
                .Include(order => order.Employee).ThenInclude(employee => employee.Department)
                    .ThenInclude(department => department.Company)
                .Include(order => order.Items).ThenInclude(item => item.Product)
                .Include(order => order.Items).ThenInclude(item => item.Variation)
                .ToListAsync();

            return new OrderQueryResult
            {
                CreatedAt = filters.CreatedAt,
                Companies = orders.GroupBy(order => order.Employee.Department.CompanyId)
                    .Select(order => order.First().Employee.Department.Company)
                    .ToList()
            };
        }
    }
}
