using System;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Product;
using Restaurant.Application.Interfaces;
using Restaurant.Application.QueryParams;
using Restaurant.Application.Wrappers;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(ProductPostDTO dto)
        {
            var insertedDto = _service.Insert(dto);
            var response = new ApiResponse(insertedDto);
            var param = new { insertedDto.Id };

            // TODO: Inform the get action when implemented
            var actionName = nameof(Post);

            return CreatedAtAction(actionName, param, response);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ProductQueryParams queryParams)
        {
            var dtos = _service.GetAll(queryParams);
            var response = new ApiResponse(dtos);

            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var dto = _service.Get(id);
            var response = new ApiResponse(dto);

            return Ok(response);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Put(Guid id, ProductPutDTO dto)
        {
            var updatedDto = _service.Update(id, dto);
            var response = new ApiResponse(updatedDto);

            return Ok(response);
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);

            return NoContent();
        }
    }
}
