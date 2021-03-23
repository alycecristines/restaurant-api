using System;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.Interfaces;
using Restaurant.Application.QueryParams;
using Restaurant.Application.Wrappers;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(EmployeePostDTO dto)
        {
            var insertedDto = _service.Insert(dto);
            var response = new ApiResponse(insertedDto);
            var param = new { insertedDto.Id };

            // TODO: Inform the get action when implemented
            var actionName = nameof(Post);

            return CreatedAtAction(actionName, param, response);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] EmployeeQueryParams queryParams)
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

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);

            return NoContent();
        }
    }
}
