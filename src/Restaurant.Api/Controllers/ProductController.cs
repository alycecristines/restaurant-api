using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Product;
using Restaurant.Core.Interfaces;
using Restaurant.Core.QueryObjects;
using Restaurant.Api.Wrappers;
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
            var insertedProduct = _service.Create(newProduct);

            var insertedProductDto = _mapper.Map<ProductResponseDTO>(insertedProduct);
            var apiResponse = new Response(insertedProductDto);
            var getParams = new { insertedProductDto.Id };

            // TODO: Inform the get action when implemented
            var getActionName = nameof(Post);

            return CreatedAtAction(getActionName, getParams, apiResponse);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ProductQueryFilter filters)
        {
            var products = _service.FindAll(filters);

            var productsDto = _mapper.Map<IEnumerable<ProductResponseDTO>>(products);
            var apiResponse = new Response(productsDto);

            return Ok(apiResponse);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var product = _service.Find(id);

            var productDto = _mapper.Map<ProductResponseDTO>(product);
            var apiResponse = new Response(productDto);

            return Ok(apiResponse);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Put(Guid id, ProductPutDTO dto)
        {
            var newProduct = _mapper.Map<Product>(dto);
            var updatedProduct = _service.Update(id, newProduct);

            var updatedProductDto = _mapper.Map<ProductResponseDTO>(updatedProduct);
            var apiResponse = new Response(updatedProductDto);

            return Ok(apiResponse);
        }
    }
}
