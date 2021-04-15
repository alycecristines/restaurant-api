using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Core.Entities;
using Restaurant.Core.Exceptions;
using Restaurant.Core.Interfaces;
using Restaurant.Core.QueryFilters;

namespace Restaurant.Core.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<Company> _companyRepository;

        public DepartmentService(IRepository<Department> departmentRepository, IRepository<Company> companyRepository)
        {
            _departmentRepository = departmentRepository;
            _companyRepository = companyRepository;
        }

        public Department Create(Department newDepartment)
        {
            var existingCompany = _departmentRepository.Find(newDepartment.CompanyId);

            if (existingCompany == null)
            {
                throw new CoreException("The company was not found.");
            }

            _departmentRepository.Add(newDepartment);
            _departmentRepository.SaveChanges();

            return newDepartment;
        }

        public Department Update(Guid id, Department newDepartment)
        {
            var currentDepartment = _departmentRepository.Find(id);

            if (currentDepartment == null)
            {
                throw new CoreException("The department was not found.");
            }

            currentDepartment.Inactivated = newDepartment.Inactivated;
            currentDepartment.Description = newDepartment.Description;
            currentDepartment.UpdatedAt = DateTime.UtcNow;

            _departmentRepository.SaveChanges();

            return currentDepartment;
        }

        public IEnumerable<Department> FindAll(DepartmentQueryFilter filters)
        {
            var queryable = _departmentRepository.Queryable();

            if (!filters.IncludeInactivated)
            {
                queryable = queryable.Where(company => !company.Inactivated);
            }

            if (!string.IsNullOrWhiteSpace(filters.Description))
            {
                queryable = queryable.Where(entity =>
                    entity.Description.Contains(filters.Description));
            }

            if (filters.CompanyId.HasValue)
            {
                queryable = queryable.Where(entity =>
                    entity.CompanyId == filters.CompanyId);
            }

            return queryable.ToList();
        }

        public Department Find(Guid id)
        {
            return _departmentRepository.Find(id);
        }
    }
}
