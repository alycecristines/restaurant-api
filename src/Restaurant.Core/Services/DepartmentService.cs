using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Core.Entities;
using Restaurant.Core.Services.Base;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Repositories.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Core.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> CreateAsync(Department newDepartment)
        {
            _departmentRepository.Add(newDepartment);

            await _departmentRepository.SaveChangesAsync();

            return newDepartment;
        }

        public async Task<Department> UpdateAsync(Guid id, Department newDepartment)
        {
            var currentDepartment = await _departmentRepository.FindAsync(id);

            currentDepartment.Inactivated = newDepartment.Inactivated;
            currentDepartment.Description = newDepartment.Description;
            currentDepartment.UpdatedAt = DateTime.UtcNow;

            await _departmentRepository.SaveChangesAsync();

            return currentDepartment;
        }

        public async Task<IEnumerable<Department>> FindAllAsync(DepartmentQueryFilter filters)
        {
            var queryable = _departmentRepository.Queryable();

            if (!filters.IncludeInactivated)
            {
                queryable = queryable.Where(department =>
                    !department.Inactivated);
            }

            if (!string.IsNullOrWhiteSpace(filters.Description))
            {
                queryable = queryable.Where(department =>
                    EF.Functions.Like(department.Description, $"%{filters.Description}%"));
            }

            if (filters.CompanyId.HasValue)
            {
                queryable = queryable.Where(department =>
                    department.CompanyId == filters.CompanyId);
            }

            return await queryable.ToListAsync();
        }

        public async Task<Department> FindAsync(Guid id)
        {
            return await _departmentRepository.FindAsync(id);
        }
    }
}
