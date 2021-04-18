using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Core.Entities;
using Restaurant.Core.Exceptions;
using Restaurant.Core.Services.Base;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Repositories.Base;

namespace Restaurant.Core.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyService(IRepository<Company> repository)
        {
            _companyRepository = repository;
        }

        public Company Create(Company newCompany)
        {
            var existingCompany = _companyRepository.Queryable().FirstOrDefault(entity =>
                entity.RegistrationNumber == newCompany.RegistrationNumber);

            if (existingCompany != null)
            {
                throw new CoreException("There is already a company registered with this registration number.");
            }

            _companyRepository.Add(newCompany);
            _companyRepository.SaveChanges();

            return newCompany;
        }

        public Company Update(Guid id, Company newCompany)
        {
            var currentCompany = _companyRepository.Find(id);

            if (currentCompany == null)
            {
                throw new CoreException("The company was not found.");
            }

            currentCompany.Inactivated = newCompany.Inactivated;
            currentCompany.CorporateName = newCompany.CorporateName;
            currentCompany.BusinessName = newCompany.BusinessName;
            currentCompany.Phone = newCompany.Phone;
            currentCompany.Address = newCompany.Address;
            currentCompany.UpdatedAt = DateTime.UtcNow;

            _companyRepository.SaveChanges();

            return currentCompany;
        }

        public IEnumerable<Company> FindAll(CompanyQueryFilter filters)
        {
            var queryable = _companyRepository.Queryable();

            if (!filters.IncludeInactivated)
            {
                queryable = queryable.Where(company => !company.Inactivated);
            }

            if (!string.IsNullOrWhiteSpace(filters.Name))
            {
                queryable = queryable.Where(company =>
                    company.CorporateName.ToLower().Contains(filters.Name.ToLower()) ||
                    company.BusinessName.ToLower().Contains(filters.Name.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(filters.RegistrationNumber))
            {
                queryable = queryable.Where(company =>
                    company.RegistrationNumber.Contains(filters.RegistrationNumber));
            }

            return queryable.ToList();
        }

        public Company Find(Guid id)
        {
            return _companyRepository.Find(id);
        }
    }
}
