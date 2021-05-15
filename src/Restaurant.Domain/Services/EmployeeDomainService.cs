using System;
using System.Collections.Generic;
using Restaurant.Domain.QueryFilters;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Extensions;

namespace Restaurant.Domain.Services
{
    public class EmployeeDomainService : IEmployeeDomainService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeDomainService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> CreateAsync(Employee newEmployee)
        {
            await ValidateCreationAsync(newEmployee);
            _employeeRepository.Add(newEmployee);
            await _employeeRepository.SaveChangesAsync();
            return newEmployee;
        }

        private async Task ValidateCreationAsync(Employee newEmployee)
        {
            if (await Exists(newEmployee.Email))
            {
                var message = $"Já existe um funcionário cadastrado com o e-mail '{newEmployee.Email}'.";
                throw new DomainException(message);
            }
        }

        private async Task<bool> Exists(string email)
        {
            return await _employeeRepository.Queryable().AnyAsync(employee => employee.Email == email);
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
            return currentEmployee;
        }

        public async Task<IEnumerable<Employee>> FindAllAsync(EmployeeQueryFilter filters)
        {
            return await _employeeRepository.Queryable()
                .WhereFor(!filters.IncludeInactivated, employee => !employee.Inactivated)
                .WhereFor(filters.Name, employee => EF.Functions.Like(employee.Name, $"%{filters.Name}%"))
                .WhereFor(filters.Email, employee => EF.Functions.Like(employee.Email, $"%{filters.Email}%"))
                .WhereFor(filters.CompanyId, employee => employee.Department.CompanyId == filters.CompanyId)
                .WhereFor(filters.DepartmentId, employee => employee.DepartmentId == filters.DepartmentId)
                .ToListAsync();
        }

        public async Task<Employee> FindAsync(Guid id)
        {
            return await _employeeRepository.FindAsync(id);
        }
    }
}
