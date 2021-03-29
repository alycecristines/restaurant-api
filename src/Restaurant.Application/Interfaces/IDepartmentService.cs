using System;
using System.Collections.Generic;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Interfaces
{
    public interface IDepartmentService
    {
        Department Insert(Department dto);
        IEnumerable<Department> GetAll(DepartmentQueryParams queryParams);
        Department Get(Guid id);
        Department Update(Guid id, Department dto);
        void Delete(Guid id);
    }
}
