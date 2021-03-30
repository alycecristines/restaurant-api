using Restaurant.Application.Interfaces;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;

namespace Restaurant.Application.Services
{
    public class VariationService : IVariationService
    {
        private readonly IRepository<Variation> _variationRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IServiceValidator _validator;

        public VariationService(IRepository<Variation> variationRepository,
            IRepository<Product> productRepository, IServiceValidator validator)
        {
            _variationRepository = variationRepository;
            _productRepository = productRepository;
            _validator = validator;
        }

        public Variation Insert(Variation newVariation)
        {
            var existingProduct = _productRepository.Get(newVariation.ProductId);

            _validator.Found(existingProduct);

            _variationRepository.Insert(newVariation);
            _variationRepository.SaveChanges();

            return newVariation;
        }
    }
}
