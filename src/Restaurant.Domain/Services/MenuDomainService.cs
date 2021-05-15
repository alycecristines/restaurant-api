using System;
using System.Collections.Generic;
using Restaurant.Domain.QueryFilters;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Extensions;

namespace Restaurant.Domain.Services
{
    public class MenuDomainService : IMenuDomainService
    {
        private readonly IRepository<Menu> _menuRepository;
        private readonly IRepository<Product> _productRepository;

        public MenuDomainService(IRepository<Menu> menuRepository, IRepository<Product> productRepository)
        {
            _menuRepository = menuRepository;
            _productRepository = productRepository;
        }

        public async Task<Menu> CreateAsync(Menu newMenu)
        {
            newMenu.Products = await GetValidatedProductsAsync(newMenu.Products);
            _menuRepository.Add(newMenu);
            await _menuRepository.SaveChangesAsync();
            return newMenu;
        }

        public async Task<Menu> UpdateAsync(Guid id, Menu newMenu)
        {
            var currentMenu = await _menuRepository.Queryable().Include(menu => menu.Products)
                .FirstOrDefaultAsync(menu => menu.Id == id);

            currentMenu.Inactivated = newMenu.Inactivated;
            currentMenu.Products.Clear();
            currentMenu.Products = await GetValidatedProductsAsync(newMenu.Products);
            currentMenu.Description = newMenu.Description;
            currentMenu.UpdatedAt = DateTime.UtcNow;

            await _menuRepository.SaveChangesAsync();
            return currentMenu;
        }

        private async Task<IList<Product>> GetValidatedProductsAsync(IEnumerable<Product> products)
        {
            var validatedProducts = new List<Product>();

            foreach (var product in products)
            {
                var existingProduct = await _productRepository.FindAsync(product.Id);
                validatedProducts.Add(existingProduct);
            }

            return validatedProducts;
        }

        public async Task<IEnumerable<Menu>> FindAllAsync(MenuQueryFilter filters)
        {
            return await _menuRepository.Queryable()
                .WhereFor(!filters.IncludeInactivated, menu => !menu.Inactivated)
                .WhereFor(filters.Description, menu => EF.Functions.Like(menu.Description, $"%{filters.Description}%"))
                .ToListAsync();
        }

        public async Task<Menu> FindAsync(Guid id)
        {
            return await _menuRepository.FindAsync(id);
        }
    }
}
