using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Core.Interfaces;
using Restaurant.Core.QueryObjects;
using Restaurant.Core.Entities;
using Restaurant.Core.Exceptions;

namespace Restaurant.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Department> _departmentRepository;

        public EmployeeService(IRepository<Employee> employeeRepository, IRepository<Department> departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public Employee Create(Employee newEmployee)
        {
            var existingDepartment = _departmentRepository.Find(newEmployee.DepartmentId);

            if (existingDepartment == null)
            {
                throw new CoreException("Não encontrado");
            }

            _employeeRepository.Add(newEmployee);
            _employeeRepository.SaveChanges();

            return newEmployee;
        }

        public Employee Update(Guid id, Employee newEmployee)
        {
            var existingDepartment = _departmentRepository.Find(newEmployee.DepartmentId);

            if (existingDepartment == null)
            {
                throw new CoreException("Não encontrado");
            }

            var currentEmployee = _employeeRepository.Find(id);

            if (currentEmployee == null)
            {
                throw new CoreException("Não encontrado");
            }

            currentEmployee.Inactivated = newEmployee.Inactivated;
            currentEmployee.Name = newEmployee.Name;
            currentEmployee.Email = newEmployee.Email;
            currentEmployee.DepartmentId = newEmployee.DepartmentId;
            currentEmployee.UpdatedAt = DateTime.UtcNow;

            _employeeRepository.SaveChanges();

            return currentEmployee;
        }

        public IEnumerable<Employee> FindAll(EmployeeQueryFilter filters)
        {
            var queryable = _employeeRepository.Queryable();

            if (!filters.IncludeInactivated)
            {
                queryable = queryable.Where(company => !company.Inactivated);
            }

            if (!string.IsNullOrWhiteSpace(filters.Name))
            {
                queryable = queryable.Where(entity =>
                    entity.Name.Contains(filters.Name));
            }

            if (!string.IsNullOrWhiteSpace(filters.Email))
            {
                queryable = queryable.Where(entity =>
                    entity.Email.Contains(filters.Email));
            }

            if (filters.CompanyId.HasValue)
            {
                queryable = queryable.Where(entity =>
                    entity.Department.CompanyId == filters.CompanyId);
            }

            if (filters.DepartmentId.HasValue)
            {
                queryable = queryable.Where(entity =>
                    entity.DepartmentId == filters.DepartmentId);
            }

            return queryable.ToList();
        }

        public Employee Find(Guid id)
        {
            return _employeeRepository.Find(id);
        }
    }
}
