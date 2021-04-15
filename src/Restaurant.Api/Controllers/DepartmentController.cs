using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Department;
using Restaurant.Core.Interfaces;
using Restaurant.Core.QueryObjects;
using Restaurant.Application.Wrappers;
using Restaurant.Core.Entities;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(DepartmentPostDTO dto)
        {
            var newDepartment = _mapper.Map<Department>(dto);
            var insertedDepartment = _service.Create(newDepartment);

            var insertedDepartmentDto = _mapper.Map<DepartmentResponseDTO>(insertedDepartment);
            var apiResponse = new Response(insertedDepartmentDto);
            var getParams = new { insertedDepartmentDto.Id };

            // TODO: Inform the get action when implemented
            var getActionName = nameof(Post);

            return CreatedAtAction(getActionName, getParams, apiResponse);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] DepartmentQueryFilter filters)
        {
            var departments = _service.FindAll(filters);

            var departmentsDto = _mapper.Map<IEnumerable<DepartmentResponseDTO>>(departments);
            var apiResponse = new Response(departmentsDto);

            return Ok(apiResponse);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var department = _service.Find(id);

            var departmentDto = _mapper.Map<DepartmentResponseDTO>(department);
            var apiResponse = new Response(departmentDto);

            return Ok(apiResponse);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Put(Guid id, DepartmentPutDTO dto)
        {
            var newDepartment = _mapper.Map<Department>(dto);
            var updatedDepartment = _service.Update(id, newDepartment);

            var updatedDepartmentDto = _mapper.Map<DepartmentResponseDTO>(updatedDepartment);
            var apiResponse = new Response(updatedDepartmentDto);

            return Ok(apiResponse);
        }
    }
}
