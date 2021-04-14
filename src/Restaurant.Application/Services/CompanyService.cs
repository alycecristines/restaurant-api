using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Application.Extensions;
using Restaurant.Application.Interfaces;
using Restaurant.Core.QueryObjects;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;

namespace Restaurant.Application.Services
{
    // TODO: Refactor
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IServiceValidator _validator;

        public CompanyService(IRepository<Company> companyRepository,
            IRepository<Department> departmentRepository, IServiceValidator validator)
        {
            _companyRepository = companyRepository;
            _departmentRepository = departmentRepository;
            _validator = validator;
        }

        public Company Insert(Company newCompany)
        {
            var existingCompany = _companyRepository.GetAll().FirstOrDefault(entity =>
                entity.RegistrationNumber == newCompany.RegistrationNumber);

            _validator.NotExist(existingCompany);

            _companyRepository.Insert(newCompany);
            _companyRepository.SaveChanges();

            return newCompany;
        }

        public IEnumerable<Company> GetAll(CompanyQuery queryParams)
        {
            var query = _companyRepository.GetAll(queryParams.IncludeDeleted, queryParams.IncludeInactivated);

            if (!string.IsNullOrWhiteSpace(queryParams.Name))
            {
                query = query.Where(entity =>
                    entity.CorporateName.ContainsResearch(queryParams.Name) ||
                    entity.BusinessName.ContainsResearch(queryParams.Name));
            }

            if (!string.IsNullOrWhiteSpace(queryParams.RegistrationNumber))
            {
                query = query.Where(entity => entity.RegistrationNumber.ContainsResearch(queryParams.RegistrationNumber));
            }

            return query.ToList();
        }

        public Company Get(Guid id)
        {
            var company = _companyRepository.Get(id);

            _validator.Found(company);

            return company;
        }

        public Company Update(Guid id, Company newCompany)
        {
            var currentCompany = _companyRepository.Get(id);

            _validator.Found(currentCompany);
            _validator.NotDeleted(currentCompany);

            currentCompany.Inactivated = newCompany.Inactivated;
            currentCompany.CorporateName = newCompany.CorporateName;
            currentCompany.BusinessName = newCompany.BusinessName;
            currentCompany.Phone = newCompany.Phone;
            currentCompany.Address = newCompany.Address;
            currentCompany.Update(DateTime.UtcNow);

            _companyRepository.SaveChanges();

            return currentCompany;
        }

        public void Delete(Guid id)
        {
            var company = _companyRepository.Get(id);

            _validator.Found(company);
            _validator.NotDeleted(company);

            var relatedDepartment = _departmentRepository.GetAll()
                .FirstOrDefault(entity => entity.CompanyId == id);

            _validator.HasNoRelated(relatedDepartment);

            company.Delete(DateTime.UtcNow);

            _companyRepository.SaveChanges();
        }
    }
}
