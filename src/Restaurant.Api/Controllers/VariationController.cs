using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Variation;
using Restaurant.Core.Interfaces;
using Restaurant.Core.QueryFilters;
using Restaurant.Api.Wrappers;
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
            var insertedVariation = _service.Create(newVariation);

            var insertedVariationtDto = _mapper.Map<VariationResponseDTO>(insertedVariation);
            var apiResponse = new Response(insertedVariationtDto);
            var getParams = new { insertedVariationtDto.Id };

            // TODO: Inform the get action when implemented
            var getActionName = nameof(Post);

            return CreatedAtAction(getActionName, getParams, apiResponse);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] VariationQueryFilter filters)
        {
            var variations = _service.FindAll(filters);

            var variationsDto = _mapper.Map<IEnumerable<VariationResponseDTO>>(variations);
            var apiResponse = new Response(variationsDto);

            return Ok(apiResponse);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var variation = _service.Find(id);

            var variationDto = _mapper.Map<VariationResponseDTO>(variation);
            var apiResponse = new Response(variationDto);

            return Ok(apiResponse);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Put(Guid id, VariationPutDTO dto)
        {
            var newVariation = _mapper.Map<Variation>(dto);
            var updatedVariation = _service.Update(id, newVariation);

            var updatedVariationDto = _mapper.Map<VariationResponseDTO>(updatedVariation);
            var apiResponse = new Response(updatedVariationDto);

            return Ok(apiResponse);
        }
    }
}
