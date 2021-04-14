using System;
using System.Collections.Generic;
using Restaurant.Core.QueryObjects;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Interfaces
{
    public interface IEmployeeService
    {
        Employee Insert(Employee newEmployee);
        IEnumerable<Employee> GetAll(EmployeeQuery queryParams);
        Employee Get(Guid id);
        Employee Update(Guid id, Employee newEmployee);
        void Delete(Guid id);
    }
}
