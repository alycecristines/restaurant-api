using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.QueryFilters;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Infrastructure.Identity.Constants;
using Restaurant.Application.Interfaces;
using System.Threading.Tasks;
using Restaurant.Application.Models.Menu;
using Restaurant.Api.Wrappers;
using System;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("api/menus")]
    [Authorize(Roles = RoleConstants.Administrator)]
    public class MenuController : ControllerBase
    {
        private readonly IMenuApplicationService _menuService;

        public MenuController(IMenuApplicationService menuService)
        {
            _menuService = menuService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(MenuCreateModel model)
        {
            var createdMenu = await _menuService.CreateAsync(model);
            var response = new Response(createdMenu);
            var getParams = new { createdMenu.Id };
            return CreatedAtAction(nameof(Get), getParams, response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, MenuUpdateModel model)
        {
            var updatedMenu = await _menuService.UpdateAsync(id, model);
            var response = new Response(updatedMenu);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] MenuQueryFilter filters)
        {
            var menus = await _menuService.FindAllAsync(filters);
            var response = new Response(menus);
            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var menu = await _menuService.FindAsync(id);
            var response = new Response(menu);
            return Ok(response);
        }
    }
}
