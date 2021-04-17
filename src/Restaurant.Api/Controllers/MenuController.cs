using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Menu;
using Restaurant.Core.Interfaces;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;
using Restaurant.Api.Controllers.Base;

namespace Restaurant.Api.Controllers
{
    [Route("api/menus")]
    public class MenuController : ApiController<Menu, MenuPostDTO,
        MenuPutDTO, MenuResponseDTO, MenuQueryFilter>
    {
        public MenuController(IMenuService service,
            IMapper mapper) : base(service, mapper)
        {
        }
    }
}
