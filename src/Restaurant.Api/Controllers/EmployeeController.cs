using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Employee;
using Restaurant.Core.Interfaces;
using Restaurant.Core.QueryObjects;
using Restaurant.Application.Wrappers;
using Restaurant.Core.Entities;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(EmployeePostDTO dto)
        {
            var newEmployee = _mapper.Map<Employee>(dto);
            var insertedEmployee = _service.Create(newEmployee);

            var insertedEmployeeDto = _mapper.Map<EmployeeResponseDTO>(insertedEmployee);
            var apiResponse = new Response(insertedEmployeeDto);
            var getParams = new { insertedEmployeeDto.Id };

            // TODO: Inform the get action when implemented
            var getActionName = nameof(Post);

            return CreatedAtAction(getActionName, getParams, apiResponse);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] EmployeeQueryFilter filters)
        {
            var employees = _service.FindAll(filters);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeResponseDTO>>(employees);
            var apiResponse = new Response(employeesDto);

            return Ok(apiResponse);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var employee = _service.Find(id);

            var employeeDto = _mapper.Map<EmployeeResponseDTO>(employee);
            var apiResponse = new Response(employeeDto);

            return Ok(apiResponse);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Put(Guid id, EmployeePutDTO dto)
        {
            var newEmployee = _mapper.Map<Employee>(dto);
            var updatedEmployee = _service.Update(id, newEmployee);

            var updatedEmployeeDto = _mapper.Map<EmployeeResponseDTO>(updatedEmployee);
            var apiResponse = new Response(updatedEmployeeDto);

            return Ok(apiResponse);
        }
    }
}
