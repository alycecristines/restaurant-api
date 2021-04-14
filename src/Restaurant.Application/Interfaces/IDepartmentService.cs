using System;
using System.Collections.Generic;
using Restaurant.Core.QueryObjects;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Interfaces
{
    public interface IDepartmentService
    {
        Department Insert(Department newDepartment);
        IEnumerable<Department> GetAll(DepartmentQuery queryParams);
        Department Get(Guid id);
        Department Update(Guid id, Department newDepartment);
        void Delete(Guid id);
    }
}
