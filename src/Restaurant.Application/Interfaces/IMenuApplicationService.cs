using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Application.Models.Menu;
using Restaurant.Domain.QueryFilters;

namespace Restaurant.Application.Interfaces
{
    public interface IMenuApplicationService
    {
        Task<MenuResponseModel> CreateAsync(MenuCreateModel model);
        Task<MenuResponseModel> UpdateAsync(Guid id, MenuUpdateModel model);
        Task<IEnumerable<MenuResponseModel>> FindAllAsync(MenuQueryFilter filters);
        Task<MenuResponseModel> FindAsync(Guid id);
    }
}
