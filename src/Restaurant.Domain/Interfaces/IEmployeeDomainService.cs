using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.QueryFilters;

namespace Restaurant.Domain.Interfaces
{
    public interface IEmployeeDomainService
    {
        Task<Employee> CreateAsync(Employee newEmployee);
        Task<Employee> UpdateAsync(Guid id, Employee newEmployee);
        Task<IEnumerable<Employee>> FindAllAsync(EmployeeQueryFilter filters);
        Task<Employee> FindAsync(Guid id);
    }
}
