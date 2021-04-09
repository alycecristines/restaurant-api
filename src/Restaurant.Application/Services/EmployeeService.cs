using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Application.Extensions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;

namespace Restaurant.Application.Services
{
    // TODO: Refactor
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IServiceValidator _validator;

        public EmployeeService(IRepository<Employee> employeeRepository,
            IRepository<Department> departmentRepository, IServiceValidator validator)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _validator = validator;
        }

        public Employee Insert(Employee newEmployee)
        {
            var existingDepartment = _departmentRepository.Get(newEmployee.DepartmentId);

            _validator.Found(existingDepartment);
            _validator.NotDeleted(existingDepartment);

            _employeeRepository.Insert(newEmployee);
            _employeeRepository.SaveChanges();

            return newEmployee;
        }

        public IEnumerable<Employee> GetAll(EmployeeQueryParams queryParams)
        {
            var query = _employeeRepository.GetAll(queryParams.IncludeDeleted, queryParams.IncludeInactivated);

            if (!string.IsNullOrWhiteSpace(queryParams.Name))
            {
                query = query.Where(entity =>
                    entity.Name.ContainsResearch(queryParams.Name));
            }

            if (!string.IsNullOrWhiteSpace(queryParams.Email))
            {
                query = query.Where(entity =>
                    entity.Email.ContainsResearch(queryParams.Email));
            }

            if (queryParams.DepartmentId.HasValue)
            {
                query = query.Where(entity =>
                    entity.DepartmentId == queryParams.DepartmentId);
            }

            return query.ToList();
        }

        public Employee Get(Guid id)
        {
            var employee = _employeeRepository.Get(id);

            _validator.Found(employee);

            return employee;
        }

        public Employee Update(Guid id, Employee newEmployee)
        {
            var existingDepartment = _departmentRepository.Get(newEmployee.DepartmentId);

            _validator.Found(existingDepartment);
            _validator.NotDeleted(existingDepartment);

            var currentEmployee = _employeeRepository.Get(id);

            _validator.Found(currentEmployee);
            _validator.NotDeleted(currentEmployee);

            currentEmployee.Inactivated = newEmployee.Inactivated;
            currentEmployee.Name = newEmployee.Name;
            currentEmployee.Email = newEmployee.Email;
            currentEmployee.DepartmentId = newEmployee.DepartmentId;
            currentEmployee.Update(DateTime.UtcNow);

            _employeeRepository.SaveChanges();

            return currentEmployee;
        }

        public void Delete(Guid id)
        {
            var employee = _employeeRepository.Get(id);

            _validator.Found(employee);
            _validator.NotDeleted(employee);

            employee.Delete(DateTime.UtcNow);

            _employeeRepository.SaveChanges();
        }
    }
}
