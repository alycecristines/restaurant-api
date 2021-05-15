using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.QueryFilters;

namespace Restaurant.Domain.Interfaces
{
    public interface IMenuDomainService
    {
        Task<Menu> CreateAsync(Menu newMenu);
        Task<Menu> UpdateAsync(Guid id, Menu newMenu);
        Task<IEnumerable<Menu>> FindAllAsync(MenuQueryFilter filters);
        Task<Menu> FindAsync(Guid id);
    }
}
