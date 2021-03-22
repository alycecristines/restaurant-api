using System;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Wrappers;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(CompanyPostDTO dto)
        {
            _service.Insert(dto);
            var response = new ApiSuccessResponse();
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dtos = _service.GetAll();
            var response = new ApiSuccessResponse(dtos);
            return Ok(response);
        }

        [HttpGet("{nameOrRegistrationNumber}")]
        public IActionResult Get(string nameOrRegistrationNumber)
        {
            var dtos = _service.GetAll(nameOrRegistrationNumber);
            var response = new ApiSuccessResponse(dtos);
            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var dto = _service.Get(id);
            var response = new ApiSuccessResponse(dto);
            return Ok(response);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Put(Guid id, CompanyPutDTO dto)
        {
            _service.Update(id, dto);
            var response = new ApiSuccessResponse();
            return Ok(response);
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            var response = new ApiSuccessResponse();
            return Ok(response);
        }
    }
}
