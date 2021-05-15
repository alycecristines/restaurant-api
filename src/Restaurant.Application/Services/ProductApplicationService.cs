using System.Threading.Tasks;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Entities;
using System.Collections.Generic;
using Restaurant.Domain.QueryFilters;
using System;
using AutoMapper;
using Restaurant.Application.Models.Product;

namespace Restaurant.Application.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductDomainService _productService;
        private readonly IMapper _mapper;

        public ProductApplicationService(IProductDomainService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<ProductResponseModel> CreateAsync(ProductCreateModel model)
        {
            var newProduct = _mapper.Map<Product>(model);
            var createdProduct = await _productService.CreateAsync(newProduct);
            return _mapper.Map<ProductResponseModel>(createdProduct);
        }

        public async Task<ProductResponseModel> UpdateAsync(Guid id, ProductUpdateModel model)
        {
            var newProduct = _mapper.Map<Product>(model);
            var updatedProduct = await _productService.UpdateAsync(id, newProduct);
            return _mapper.Map<ProductResponseModel>(updatedProduct);
        }

        public async Task<IEnumerable<ProductResponseModel>> FindAllAsync(ProductQueryFilter filters)
        {
            var products = await _productService.FindAllAsync(filters);
            return _mapper.Map<IEnumerable<ProductResponseModel>>(products);
        }

        public async Task<ProductResponseModel> FindAsync(Guid id)
        {
            var product = await _productService.FindAsync(id);
            return _mapper.Map<ProductResponseModel>(product);
        }
    }
}
