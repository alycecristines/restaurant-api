using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Core.Services.Base;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IAccountService _accountService;

        public EmployeeService(IRepository<Employee> employeeRepository, IAccountService accountService)
        {
            _employeeRepository = employeeRepository;
            _accountService = accountService;
        }

        public async Task<Employee> CreateAsync(Employee newEmployee)
        {
            _employeeRepository.Add(newEmployee);

            await _employeeRepository.SaveChangesAsync();
            await _accountService.CreateAsync(newEmployee);

            return newEmployee;
        }

        public async Task<Employee> UpdateAsync(Guid id, Employee newEmployee)
        {
            var currentEmployee = await _employeeRepository.FindAsync(id);

            currentEmployee.Inactivated = newEmployee.Inactivated;
            currentEmployee.Name = newEmployee.Name;
            currentEmployee.Email = newEmployee.Email;
            currentEmployee.DepartmentId = newEmployee.DepartmentId;
            currentEmployee.UpdatedAt = DateTime.UtcNow;

            await _employeeRepository.SaveChangesAsync();

            if (currentEmployee.Inactivated)
            {
                await _accountService.DeleteAsync(currentEmployee);
            }
            else
            {
                await _accountService.UpdateAsync(currentEmployee);
            }

            return currentEmployee;
        }

        public async Task<IEnumerable<Employee>> FindAllAsync(EmployeeQueryFilter filters)
        {
            var queryable = _employeeRepository.Queryable();

            if (!filters.IncludeInactivated)
            {
                queryable = queryable.Where(employee =>
                    !employee.Inactivated);
            }

            if (!string.IsNullOrWhiteSpace(filters.Name))
            {
                queryable = queryable.Where(employee =>
                    EF.Functions.Like(employee.Name, $"%{filters.Name}%"));
            }

            if (!string.IsNullOrWhiteSpace(filters.Email))
            {
                queryable = queryable.Where(employee =>
                    EF.Functions.Like(employee.Email, $"%{filters.Email}%"));
            }

            if (filters.CompanyId.HasValue)
            {
                queryable = queryable.Where(employee =>
                    employee.Department.CompanyId == filters.CompanyId);
            }

            if (filters.DepartmentId.HasValue)
            {
                queryable = queryable.Where(employee =>
                    employee.DepartmentId == filters.DepartmentId);
            }

            return await queryable.ToListAsync();
        }

        public async Task<Employee> FindAsync(Guid id)
        {
            return await _employeeRepository.FindAsync(id);
        }
    }
}
