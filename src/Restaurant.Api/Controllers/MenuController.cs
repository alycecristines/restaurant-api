using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Menu;
using Restaurant.Application.Interfaces;
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
            var apiResponse = new ApiResponse(insertedMenuDto);
            var getParams = new { insertedMenuDto.Id };

            // TODO: Inform the get action when implemented
            var getActionName = nameof(Post);

            return CreatedAtAction(getActionName, getParams, apiResponse);
        }
    }
}
