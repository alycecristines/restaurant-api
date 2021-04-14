using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Menu;
using Restaurant.Application.Interfaces;
using Restaurant.Core.QueryObjects;
using Restaurant.Application.Wrappers;
using Restaurant.Core.Entities;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/menus")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _service;
        private readonly IMapper _mapper;

        public MenuController(IMenuService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(MenuPostDTO dto)
        {
            var newMenu = _mapper.Map<Menu>(dto);
            var insertedMenu = _service.Insert(newMenu);

            var insertedMenuDto = _mapper.Map<MenuResponseDTO>(insertedMenu);
            var apiResponse = new Response(insertedMenuDto);
            var getParams = new { insertedMenuDto.Id };

            // TODO: Inform the get action when implemented
            var getActionName = nameof(Post);

            return CreatedAtAction(getActionName, getParams, apiResponse);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] MenuQuery queryParams)
        {
            var menus = _service.GetAll(queryParams);

            var menusDto = _mapper.Map<IEnumerable<MenuResponseDTO>>(menus);
            var apiResponse = new Response(menusDto);

            return Ok(apiResponse);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var menu = _service.Get(id);

            var menuDto = _mapper.Map<MenuResponseDTO>(menu);
            var apiResponse = new Response(menuDto);

            return Ok(apiResponse);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Put(Guid id, MenuPutDTO dto)
        {
            var newMenu = _mapper.Map<Menu>(dto);
            var updatedMenu = _service.Update(id, newMenu);

            var updatedMenuDto = _mapper.Map<MenuResponseDTO>(updatedMenu);
            var apiResponse = new Response(updatedMenuDto);

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
