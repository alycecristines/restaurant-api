using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Models.Department;
using Restaurant.Domain.QueryFilters;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Infrastructure.Identity.Constants;
using Restaurant.Application.Interfaces;
using System.Threading.Tasks;
using Restaurant.Api.Wrappers;
using System;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/departments")]
    [Authorize(Roles = RoleConstants.Administrator)]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentApplicationService _departmentService;

        public DepartmentController(IDepartmentApplicationService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(DepartmentCreateModel model)
        {
            var createdDepartment = await _departmentService.CreateAsync(model);
            var response = new Response(createdDepartment);
            var getParams = new { createdDepartment.Id };
            return CreatedAtAction(nameof(Get), getParams, response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, DepartmentUpdateModel model)
        {
            var updatedDepartment = await _departmentService.UpdateAsync(id, model);
            var response = new Response(updatedDepartment);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DepartmentQueryFilter filters)
        {
            var departments = await _departmentService.FindAllAsync(filters);
            var response = new Response(departments);
            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var department = await _departmentService.FindAsync(id);
            var response = new Response(department);
            return Ok(response);
        }
    }
}
