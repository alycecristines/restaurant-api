using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.QueryFilters;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Infrastructure.Identity.Constants;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Models.Variation;
using System.Threading.Tasks;
using Restaurant.Api.Wrappers;
using System;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/variations")]
    public class VariationController : ControllerBase
    {
        private readonly IVariationApplicationService _variationService;

        public VariationController(IVariationApplicationService variationService)
        {
            _variationService = variationService;
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.Administrator)]
        public async Task<IActionResult> Post(VariationCreateModel model)
        {
            var createdVariation = await _variationService.CreateAsync(model);
            var response = new Response(createdVariation);
            var getParams = new { createdVariation.Id };
            return CreatedAtAction(nameof(Get), getParams, response);
        }

        [HttpPut("{id:Guid}")]
        [Authorize(Roles = RoleConstants.Administrator)]
        public async Task<IActionResult> Put(Guid id, VariationUpdateModel model)
        {
            var updatedVariation = await _variationService.UpdateAsync(id, model);
            var response = new Response(updatedVariation);
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] VariationQueryFilter filters)
        {
            var variations = await _variationService.FindAllAsync(filters);
            var response = new Response(variations);
            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> Get(Guid id)
        {
            var variation = await _variationService.FindAsync(id);
            var response = new Response(variation);
            return Ok(response);
        }
    }
}
