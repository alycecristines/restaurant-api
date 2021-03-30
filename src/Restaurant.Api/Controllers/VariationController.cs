using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Variation;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Wrappers;
using Restaurant.Core.Entities;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/variations")]
    public class VariationController : ControllerBase
    {
        private readonly IVariationService _service;
        private readonly IMapper _mapper;

        public VariationController(IVariationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(VariationPostDTO dto)
        {
            var newVariation = _mapper.Map<Variation>(dto);
            var insertedVariation = _service.Insert(newVariation);

            var insertedVariationtDto = _mapper.Map<VariationResponseDTO>(insertedVariation);
            var apiResponse = new ApiResponse(insertedVariationtDto);
            var getParams = new { insertedVariationtDto.Id };

            // TODO: Inform the get action when implemented
            var getActionName = nameof(Post);

            return CreatedAtAction(getActionName, getParams, apiResponse);
        }
    }
}
