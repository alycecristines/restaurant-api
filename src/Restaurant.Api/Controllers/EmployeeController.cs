using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.Interfaces;
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
    }
}
