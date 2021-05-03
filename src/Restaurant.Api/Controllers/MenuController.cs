using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Menu;
using Restaurant.Core.Services.Base;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;
using Restaurant.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Infrastructure.Identity.Constants;

namespace Restaurant.Api.Controllers
{
    [Route("api/menus")]
    [Authorize(Roles = RoleConstants.Administrator)]
    public class MenuController : ApiControllerBase<Menu, MenuPostDTO, MenuPutDTO, MenuResponseDTO, MenuQueryFilter>
    {
        public MenuController(IMenuService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
