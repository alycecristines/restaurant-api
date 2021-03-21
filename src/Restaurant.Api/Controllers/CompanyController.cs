using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.DTOs.Request;
using Restaurant.Core.DTOs.Response;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Post(CompanyPostDTO dto)
        {
            var entity = _mapper.Map<Company>(dto);
            await _service.Insert(entity);
            return Ok(true);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entities = await _service.GetAsync();
            var dtos = _mapper.Map<IEnumerable<CompanyResponseDTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("{nameOrRegistrationNumber}")]
        public async Task<IActionResult> Get(string nameOrRegistrationNumber)
        {
            var entities = await _service.GetAsync(nameOrRegistrationNumber);
            var dtos = _mapper.Map<IEnumerable<CompanyResponseDTO>>(entities);
            return Ok(dtos);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = await _service.GetAsync(id);
            var dto = _mapper.Map<CompanyResponseDTO>(entity);
            return Ok(dto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CompanyPutDTO dto)
        {
            var entity = _mapper.Map<Company>(dto);
            await _service.Update(entity);
            return Ok(true);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return Ok(true);
        }
    }
}
