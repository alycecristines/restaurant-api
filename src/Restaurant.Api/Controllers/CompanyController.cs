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
    }
}
