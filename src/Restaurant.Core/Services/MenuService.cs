using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Core.Services.Base;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Core.Services
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<Menu> _menuRepository;
        private readonly IRepository<Product> _productRepository;

        public MenuService(IRepository<Menu> menuRepository, IRepository<Product> productRepository)
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
            var currentMenu = await _menuRepository.FindAsync(id);

            currentMenu.Inactivated = newMenu.Inactivated;
            currentMenu.Products = await GetValidatedProductsAsync(newMenu.Products);
            currentMenu.Description = newMenu.Description;
            currentMenu.UpdatedAt = DateTime.UtcNow;

            await _menuRepository.SaveChangesAsync();

            return currentMenu;
        }

        public async Task<IEnumerable<Menu>> FindAllAsync(MenuQueryFilter filters)
        {
            var queryable = _menuRepository.Queryable();

            if (!filters.IncludeInactivated)
            {
                queryable = queryable.Where(menu =>
                    !menu.Inactivated);
            }

            if (!string.IsNullOrWhiteSpace(filters.Description))
            {
                queryable = queryable.Where(menu =>
                    EF.Functions.Like(menu.Description, $"%{filters.Description}%"));
            }

            return await queryable.ToListAsync();
        }

        public async Task<Menu> FindAsync(Guid id)
        {
            return await _menuRepository.FindAsync(id);
        }

        private async Task<IEnumerable<Product>> GetValidatedProductsAsync(IEnumerable<Product> products)
        {
            var validatedProducts = new List<Product>();

            foreach (var product in products)
            {
                var existingProduct = await _productRepository.FindAsync(product.Id);
                validatedProducts.Add(existingProduct);
            }

            return validatedProducts;
        }
    }
}
