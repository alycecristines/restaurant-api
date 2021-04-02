using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Application.Extensions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;

namespace Restaurant.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<Menu> _menuRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IServiceValidator _validator;

        public MenuService(IRepository<Menu> menuRepository,
            IRepository<Product> productRepository, IServiceValidator validator)
        {
            _menuRepository = menuRepository;
            _productRepository = productRepository;
            _validator = validator;
        }

        public Menu Insert(Menu newMenu)
        {
            var existingProducts = new List<Product>();

            foreach (var product in newMenu.Products)
            {
                var existingProduct = _productRepository.Get(product.Id);

                _validator.Found(existingProduct);
                _validator.NotDeleted(existingProduct);

                existingProducts.Add(existingProduct);
            }

            newMenu.Products = existingProducts;

            _menuRepository.Insert(newMenu);
            _menuRepository.SaveChanges();

            return newMenu;
        }

        public IEnumerable<Menu> GetAll(MenuQueryParams queryParams)
        {
            var query = _menuRepository.GetAll(queryParams.IncludeInactive);

            if (!string.IsNullOrWhiteSpace(queryParams.Description))
            {
                query = query.Where(entity =>
                    entity.Description.ContainsResearch(queryParams.Description));
            }

            return query.ToList();
        }

        public Menu Get(Guid id)
        {
            var menu = _menuRepository.Get(id);

            _validator.Found(menu);

            return menu;
        }

        public Menu Update(Guid id, Menu newMenu)
        {
            var currentMenu = _menuRepository.Get(id);

            _validator.Found(currentMenu);
            _validator.NotDeleted(currentMenu);

            var existingProducts = new List<Product>();

            foreach (var product in newMenu.Products)
            {
                var existingProduct = _productRepository.Get(product.Id);

                _validator.Found(existingProduct);
                _validator.NotDeleted(existingProduct);

                existingProducts.Add(existingProduct);
            }

            currentMenu.Products = existingProducts;
            currentMenu.Description = newMenu.Description;
            currentMenu.Update(DateTime.UtcNow);

            _menuRepository.SaveChanges();

            return currentMenu;
        }

        public void Delete(Guid id)
        {
            var menu = _menuRepository.Get(id);

            _validator.Found(menu);
            _validator.NotDeleted(menu);

            menu.Delete(DateTime.UtcNow);

            _menuRepository.SaveChanges();
        }
    }
}
