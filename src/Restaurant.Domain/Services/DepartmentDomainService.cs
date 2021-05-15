using System;
using System.Collections.Generic;
using Restaurant.Domain.Entities;
using Restaurant.Domain.QueryFilters;
using Restaurant.Domain.Repositories.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Extensions;

namespace Restaurant.Domain.Services
{
    public class DepartmentDomainService : IDepartmentDomainService
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentDomainService(IRepository<Department> departmentRepository)
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
            return await _departmentRepository.Queryable()
                .WhereFor(!filters.IncludeInactivated, department => !department.Inactivated)
                .WhereFor(filters.Description, department => EF.Functions.Like(department.Description, $"%{filters.Description}%"))
                .WhereFor(filters.CompanyId, department => department.CompanyId == filters.CompanyId)
                .ToListAsync();
        }

        public async Task<Department> FindAsync(Guid id)
        {
            return await _departmentRepository.FindAsync(id);
        }
    }
}
