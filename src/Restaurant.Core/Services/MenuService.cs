using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Core.Interfaces;
using Restaurant.Core.QueryObjects;
using Restaurant.Core.Entities;
using Restaurant.Core.Exceptions;

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

        public Menu Create(Menu newMenu)
        {
            var existingProducts = new List<Product>();

            foreach (var product in newMenu.Products)
            {
                var existingProduct = _productRepository.Find(product.Id);

                if (existingProduct == null)
                {
                    throw new CoreException("The product was not found.");
                }

                existingProducts.Add(existingProduct);
            }

            newMenu.Products = existingProducts;

            _menuRepository.Add(newMenu);
            _menuRepository.SaveChanges();

            return newMenu;
        }

        public Menu Update(Guid id, Menu newMenu)
        {
            var currentMenu = _menuRepository.Find(id);

            if (currentMenu == null)
            {
                throw new CoreException("The menu was not found.");
            }

            var existingProducts = new List<Product>();

            foreach (var product in newMenu.Products)
            {
                var existingProduct = _productRepository.Find(product.Id);

                if (existingProduct == null)
                {
                    throw new CoreException("The product was not found.");
                }

                existingProducts.Add(existingProduct);
            }

            currentMenu.Inactivated = newMenu.Inactivated;
            currentMenu.Products = existingProducts;
            currentMenu.Description = newMenu.Description;
            currentMenu.UpdatedAt = DateTime.UtcNow;

            _menuRepository.SaveChanges();

            return currentMenu;
        }

        public IEnumerable<Menu> FindAll(MenuQueryFilter filters)
        {
            var queryable = _menuRepository.Queryable();

            if (!filters.IncludeInactivated)
            {
                queryable = queryable.Where(company => !company.Inactivated);
            }

            if (!string.IsNullOrWhiteSpace(filters.Description))
            {
                queryable = queryable.Where(entity =>
                    entity.Description.Contains(filters.Description));
            }

            return queryable.ToList();
        }

        public Menu Find(Guid id)
        {
            return _menuRepository.Find(id);
        }
    }
}
