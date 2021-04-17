using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Base;
using Restaurant.Api.Wrappers;
using Restaurant.Core.Entities.Base;
using Restaurant.Core.Services.Base;
using Restaurant.Core.QueryFilters.Base;

namespace Restaurant.Api.Controllers.Base
{
    [ApiController]
    public abstract class ApiController<TEntity, TPostDTO, TPutDTO,
        TResponseDTO, TQueryFilter> : ControllerBase
        where TEntity : Entity
        where TPutDTO : PutDTO
        where TResponseDTO : ResponseDTO
        where TQueryFilter : QueryFilter
    {
        private readonly IService<TEntity, TQueryFilter> _service;
        private readonly IMapper _mapper;

        public ApiController(IService<TEntity, TQueryFilter> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(TPostDTO dto)
        {
            var newEntity = _mapper.Map<TEntity>(dto);
            var insertedEntity = _service.Create(newEntity);

            var insertedEntityDto = _mapper.Map<TResponseDTO>(insertedEntity);
            var response = new Response(insertedEntityDto);
            var getParams = new { insertedEntityDto.Id };
            var getActionName = nameof(Get);

            return CreatedAtAction(getActionName, getParams, response);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] TQueryFilter filters)
        {
            var entities = _service.FindAll(filters);

            var entitiesDto = _mapper.Map<IEnumerable<TResponseDTO>>(entities);
            var response = new Response(entitiesDto);

            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var entity = _service.Find(id);

            var entityDto = _mapper.Map<TResponseDTO>(entity);
            var response = new Response(entityDto);

            return Ok(response);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Put(Guid id, TPutDTO dto)
        {
            var newEntity = _mapper.Map<TEntity>(dto);
            var updatedEntity = _service.Update(id, newEntity);

            var updatedEntityDto = _mapper.Map<TResponseDTO>(updatedEntity);
            var response = new Response(updatedEntityDto);

            return Ok(response);
        }
    }
}
