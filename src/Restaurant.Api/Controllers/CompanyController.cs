using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Infrastructure.Identity.Constants;
using System.Threading.Tasks;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Models.Company;
using Restaurant.Api.Wrappers;
using System;
using Restaurant.Domain.QueryFilters;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/companies")]
    [Authorize(Roles = RoleConstants.Administrator)]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyApplicationService _companyService;

        public CompanyController(ICompanyApplicationService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CompanyCreateModel model)
        {
            var createdCompany = await _companyService.CreateAsync(model);
            var response = new Response(createdCompany);
            var getParams = new { createdCompany.Id };
            return CreatedAtAction(nameof(Get), getParams, response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, CompanyUpdateModel model)
        {
            var updatedCompany = await _companyService.UpdateAsync(id, model);
            var response = new Response(updatedCompany);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CompanyQueryFilter filters)
        {
            var companies = await _companyService.FindAllAsync(filters);
            var response = new Response(companies);
            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var company = await _companyService.FindAsync(id);
            var response = new Response(company);
            return Ok(response);
        }
    }
}
