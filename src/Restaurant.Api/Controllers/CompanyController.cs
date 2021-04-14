using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Company;
using Restaurant.Application.Interfaces;
using Restaurant.Core.QueryObjects;
using Restaurant.Application.Wrappers;
using Restaurant.Core.Entities;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(CompanyPostDTO dto)
        {
            var newCompany = _mapper.Map<Company>(dto);
            var insertedCompany = _service.Insert(newCompany);

            var insertedCompanyDto = _mapper.Map<CompanyResponseDTO>(insertedCompany);
            var apiResponse = new Response(insertedCompanyDto);
            var getParams = new { insertedCompanyDto.Id };
            var getActionName = nameof(Get);

            return CreatedAtAction(getActionName, getParams, apiResponse);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] CompanyQuery queryParams)
        {
            var companies = _service.GetAll(queryParams);

            var companiesDto = _mapper.Map<IEnumerable<CompanyResponseDTO>>(companies);
            var apiResponse = new Response(companiesDto);

            return Ok(apiResponse);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var company = _service.Get(id);

            var companyDto = _mapper.Map<CompanyResponseDTO>(company);
            var apiResponse = new Response(companyDto);

            return Ok(apiResponse);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Put(Guid id, CompanyPutDTO dto)
        {
            var newCompany = _mapper.Map<Company>(dto);
            var updatedCompany = _service.Update(id, newCompany);

            var updatedCompanyDto = _mapper.Map<CompanyResponseDTO>(updatedCompany);
            var apiResponse = new Response(updatedCompanyDto);

            return Ok(apiResponse);
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);

            return NoContent();
        }
    }
}
