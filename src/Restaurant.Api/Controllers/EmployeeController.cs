using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.QueryFilters;
using Restaurant.Application.Models.Employee;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Infrastructure.Identity.Constants;
using System.Threading.Tasks;
using System;
using Restaurant.Api.Wrappers;
using Restaurant.Application.Interfaces;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/employees")]
    [Authorize(Roles = RoleConstants.Administrator)]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeApplicationService _employeeService;

        public EmployeeController(IEmployeeApplicationService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeCreateModel model)
        {
            var createdEmployee = await _employeeService.CreateAsync(model);
            var response = new Response(createdEmployee);
            var getParams = new { createdEmployee.Id };
            return CreatedAtAction(nameof(Get), getParams, response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, EmployeeUpdateModel model)
        {
            var updatedEmployee = await _employeeService.UpdateAsync(id, model);
            var response = new Response(updatedEmployee);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] EmployeeQueryFilter filters)
        {
            var employees = await _employeeService.FindAllAsync(filters);
            var response = new Response(employees);
            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var employee = await _employeeService.FindAsync(id);
            var response = new Response(employee);
            return Ok(response);
        }
    }
}
