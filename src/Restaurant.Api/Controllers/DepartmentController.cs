using System;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.Interfaces;
using Restaurant.Application.QueryParams;
using Restaurant.Application.Wrappers;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(DepartmentPostDTO dto)
        {
            var insertedDto = _service.Insert(dto);
            var response = new ApiResponse(insertedDto);
            var param = new { insertedDto.Id };

            // TODO: Inform the get action when implemented
            var actionName = nameof(Post);

            return CreatedAtAction(actionName, param, response);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] DepartmentQueryParams queryParams)
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
        public IActionResult Put(Guid id, DepartmentPutDTO dto)
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
