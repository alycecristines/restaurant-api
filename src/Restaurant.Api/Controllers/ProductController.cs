using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.QueryFilters;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Infrastructure.Identity.Constants;
using System.Threading.Tasks;
using Restaurant.Application.Models.Product;
using Restaurant.Api.Wrappers;
using System;
using Restaurant.Application.Interfaces;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Authorize(Roles = RoleConstants.Administrator)]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplicationService _productService;

        public ProductController(IProductApplicationService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductCreateModel model)
        {
            var createdProduct = await _productService.CreateAsync(model);
            var response = new Response(createdProduct);
            var getParams = new { createdProduct.Id };
            return CreatedAtAction(nameof(Get), getParams, response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, ProductUpdateModel model)
        {
            var updatedProduct = await _productService.UpdateAsync(id, model);
            var response = new Response(updatedProduct);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductQueryFilter filters)
        {
            var products = await _productService.FindAllAsync(filters);
            var response = new Response(products);
            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productService.FindAsync(id);
            var response = new Response(product);
            return Ok(response);
        }
    }
}
