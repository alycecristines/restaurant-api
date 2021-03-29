using AutoMapper;
using Restaurant.Application.DTOs.Product;
using Restaurant.Application.Interfaces;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;

namespace Restaurant.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ProductResponseDTO Insert(ProductPostDTO dto)
        {
            var newEntity = _mapper.Map<Product>(dto);

            _repository.Insert(newEntity);
            _repository.SaveChanges();

            return _mapper.Map<ProductResponseDTO>(newEntity);
        }
    }
}
