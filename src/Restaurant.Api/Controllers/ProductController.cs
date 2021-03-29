using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Product;
using Restaurant.Application.Interfaces;
using Restaurant.Application.QueryParams;
using Restaurant.Application.Wrappers;
using Restaurant.Core.Entities;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(ProductPostDTO dto)
        {
            var newProduct = _mapper.Map<Product>(dto);
            var insertedProduct = _service.Insert(newProduct);

            var insertedProductDto = _mapper.Map<ProductResponseDTO>(insertedProduct);
            var apiResponse = new ApiResponse(insertedProductDto);
            var getParams = new { insertedProductDto.Id };

            // TODO: Inform the get action when implemented
            var getActionName = nameof(Post);

            return CreatedAtAction(getActionName, getParams, apiResponse);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ProductQueryParams queryParams)
        {
            var products = _service.GetAll(queryParams);

            var productsDto = _mapper.Map<IEnumerable<ProductResponseDTO>>(products);
            var apiResponse = new ApiResponse(productsDto);

            return Ok(apiResponse);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var product = _service.Get(id);

            var productDto = _mapper.Map<ProductResponseDTO>(product);
            var apiResponse = new ApiResponse(productDto);

            return Ok(apiResponse);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Put(Guid id, ProductPutDTO dto)
        {
            var newProduct = _mapper.Map<Product>(dto);
            var updatedProduct = _service.Update(id, newProduct);

            var updatedProductDto = _mapper.Map<ProductResponseDTO>(updatedProduct);
            var apiResponse = new ApiResponse(updatedProductDto);

            return Ok(apiResponse);
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);

            return NoContent();
        }
    }
}
