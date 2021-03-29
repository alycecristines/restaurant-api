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
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IServiceValidator _validator;

        public DepartmentService(IRepository<Department> departmentRepository,
            IRepository<Company> companyRepository, IRepository<Employee> employeeRepository,
            IServiceValidator validator)
        {
            _departmentRepository = departmentRepository;
            _companyRepository = companyRepository;
            _employeeRepository = employeeRepository;
            _validator = validator;
        }

        public Department Insert(Department newDepartment)
        {
            var existingCompany = _companyRepository.Get(newDepartment.CompanyId);

            _validator.Found(existingCompany);
            _validator.NotDeleted(existingCompany);

            _departmentRepository.Insert(newDepartment);
            _departmentRepository.SaveChanges();

            return newDepartment;
        }

        public IEnumerable<Department> GetAll(DepartmentQueryParams queryParams)
        {
            var query = _departmentRepository.GetAll(queryParams.IncludeInactive);

            if (!string.IsNullOrWhiteSpace(queryParams.Description))
            {
                query = query.Where(entity =>
                    entity.Description.ContainsResearch(queryParams.Description));
            }

            if (queryParams.CompanyId.HasValue)
            {
                query = query.Where(entity =>
                    entity.CompanyId == queryParams.CompanyId);
            }

            return query.ToList();
        }

        public Department Get(Guid id)
        {
            var department = _departmentRepository.Get(id);

            _validator.Found(department);

            return department;
        }

        public Department Update(Guid id, Department newDepartment)
        {
            var currentDepartment = _departmentRepository.Get(id);

            _validator.Found(currentDepartment);
            _validator.NotDeleted(currentDepartment);

            currentDepartment.Description = newDepartment.Description;
            currentDepartment.Update(DateTime.UtcNow);

            _departmentRepository.SaveChanges();

            return currentDepartment;
        }

        public void Delete(Guid id)
        {
            var department = _departmentRepository.Get(id);

            _validator.Found(department);
            _validator.NotDeleted(department);

            var relatedEmployee = _employeeRepository.GetAll()
                .FirstOrDefault(entity => entity.DepartmentId == id);

            _validator.NotRelated(relatedEmployee);

            department.Delete(DateTime.UtcNow);

            _departmentRepository.SaveChanges();
        }
    }
}
