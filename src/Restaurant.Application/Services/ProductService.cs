using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Restaurant.Application.DTOs.Product;
using Restaurant.Application.Extensions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;
using Restaurant.Core.Exceptions;
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

        public IEnumerable<ProductResponseDTO> GetAll(ProductQueryParams queryParams)
        {
            var query = _repository.GetAll(queryParams.IncludeInactive);

            if (!string.IsNullOrWhiteSpace(queryParams.Description))
            {
                query = query.Where(entity =>
                    entity.Description.ContainsResearch(queryParams.Description));
            }

            var entities = query.ToList();

            return _mapper.Map<IEnumerable<ProductResponseDTO>>(entities);
        }

        public ProductResponseDTO Get(Guid id)
        {
            var entity = _repository.Get(id);

            if (entity == null)
            {
                throw new BusinessException($"{nameof(Product)} not found with {nameof(Product.Id)} '{id}'.");
            }

            return _mapper.Map<ProductResponseDTO>(entity);
        }

        public ProductResponseDTO Update(Guid id, ProductPutDTO dto)
        {
            var currentEntity = _repository.Get(id);

            if (currentEntity == null)
            {
                throw new BusinessException($"{nameof(Product)} not found with {nameof(Product.Id)} '{id}'.");
            }

            if (currentEntity.Deleted)
            {
                throw new BusinessException($"The {nameof(Product)} with the {nameof(Product.Id)} '{id}' has been deleted.");
            }

            var updatedEntity = _mapper.Map(dto, currentEntity);

            updatedEntity.Update(DateTime.UtcNow);
            _repository.SaveChanges();

            return _mapper.Map<ProductResponseDTO>(updatedEntity);
        }

        public void Delete(Guid id)
        {
            var entity = _repository.Get(id);

            if (entity == null)
            {
                throw new BusinessException($"{nameof(Product)} not found with {nameof(Product.Id)} '{id}'.");
            }

            if (entity.Deleted)
            {
                throw new BusinessException($"This {nameof(Product)} has already been deleted.");
            }

            entity.Delete(DateTime.UtcNow);
            _repository.SaveChanges();
        }
    }
}
