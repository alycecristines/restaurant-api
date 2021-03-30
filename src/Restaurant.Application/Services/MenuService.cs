using System.Collections.Generic;
using Restaurant.Application.Interfaces;
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
    }
}
