using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Wrappers;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            _service.Insert(dto);
            var response = new ApiSuccessResponse();
            return Ok(response);
        }
    }
}
