using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.QueryFilters;

namespace Restaurant.Domain.Interfaces
{
    public interface IDepartmentDomainService
    {
        Task<Department> CreateAsync(Department newDepartment);
        Task<Department> UpdateAsync(Guid id, Department newDepartment);
        Task<IEnumerable<Department>> FindAllAsync(DepartmentQueryFilter filters);
        Task<Department> FindAsync(Guid id);
    }
}
