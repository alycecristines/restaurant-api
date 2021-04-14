using System;
using System.Collections.Generic;
using Restaurant.Core.QueryObjects;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Interfaces
{
    public interface IMenuService
    {
        Menu Insert(Menu newMenu);
        IEnumerable<Menu> GetAll(MenuQuery queryParams);
        Menu Get(Guid id);
        Menu Update(Guid id, Menu newMenu);
        void Delete(Guid id);
    }
}
