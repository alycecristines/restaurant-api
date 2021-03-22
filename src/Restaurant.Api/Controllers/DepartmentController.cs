using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.Interfaces;
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
        public IActionResult Post(DepartmentRequestDTO dto)
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
