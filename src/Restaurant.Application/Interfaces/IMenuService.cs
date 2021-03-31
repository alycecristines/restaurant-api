using System;
using System.Collections.Generic;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Interfaces
{
    public interface IMenuService
    {
        Menu Insert(Menu newMenu);
        IEnumerable<Menu> GetAll(MenuQueryParams queryParams);
        Menu Get(Guid id);
    }
}
