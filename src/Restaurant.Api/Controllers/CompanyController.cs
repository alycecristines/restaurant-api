using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;

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
        public async Task<IActionResult> Post(Company entity)
        {
            try
            {
                var inserted = await _service.Insert(entity);
                return Ok(inserted);
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var entities = await _service.GetAsync();
                return Ok(entities);
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{nameOrRegistrationNumber}")]
        public async Task<IActionResult> Get(string nameOrRegistrationNumber)
        {
            try
            {
                var entities = await _service.GetAsync(nameOrRegistrationNumber);
                return Ok(entities);
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var entity = await _service.GetAsync(id);
                return Ok(entity);
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.Delete(id);
                return Ok(true);
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
