using System.Threading.Tasks;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Entities;
using System.Collections.Generic;
using Restaurant.Domain.QueryFilters;
using System;
using AutoMapper;
using Restaurant.Application.Models.Menu;

namespace Restaurant.Application.Services
{
    public class MenuApplicationService : IMenuApplicationService
    {
        private readonly IMenuDomainService _menuService;
        private readonly IMapper _mapper;

        public MenuApplicationService(IMenuDomainService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        public async Task<MenuResponseModel> CreateAsync(MenuCreateModel model)
        {
            var newMenu = _mapper.Map<Menu>(model);
            var createdMenu = await _menuService.CreateAsync(newMenu);
            return _mapper.Map<MenuResponseModel>(createdMenu);
        }

        public async Task<MenuResponseModel> UpdateAsync(Guid id, MenuUpdateModel model)
        {
            var newMenu = _mapper.Map<Menu>(model);
            var updatedMenu = await _menuService.UpdateAsync(id, newMenu);
            return _mapper.Map<MenuResponseModel>(updatedMenu);
        }

        public async Task<IEnumerable<MenuResponseModel>> FindAllAsync(MenuQueryFilter filters)
        {
            var menus = await _menuService.FindAllAsync(filters);
            return _mapper.Map<IEnumerable<MenuResponseModel>>(menus);
        }

        public async Task<MenuResponseModel> FindAsync(Guid id)
        {
            var menu = await _menuService.FindAsync(id);
            return _mapper.Map<MenuResponseModel>(menu);
        }
    }
}
