using System;
using System.Collections.Generic;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Interfaces
{
    public interface IEmployeeService
    {
        Employee Insert(Employee dto);
        IEnumerable<Employee> GetAll(EmployeeQueryParams queryParams);
        Employee Get(Guid id);
        Employee Update(Guid id, Employee dto);
        void Delete(Guid id);
    }
}
