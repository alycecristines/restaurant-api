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
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> CreateAsync(Company newCompany)
        {
            _companyRepository.Add(newCompany);

            await _companyRepository.SaveChangesAsync();

            return newCompany;
        }

        public async Task<Company> UpdateAsync(Guid id, Company newCompany)
        {
            var currentCompany = await _companyRepository.FindAsync(id);

            currentCompany.Inactivated = newCompany.Inactivated;
            currentCompany.CorporateName = newCompany.CorporateName;
            currentCompany.BusinessName = newCompany.BusinessName;
            currentCompany.Phone = newCompany.Phone;
            currentCompany.Address = newCompany.Address;
            currentCompany.UpdatedAt = DateTime.UtcNow;

            await _companyRepository.SaveChangesAsync();

            return currentCompany;
        }

        public async Task<IEnumerable<Company>> FindAllAsync(CompanyQueryFilter filters)
        {
            var queryable = _companyRepository.Queryable();

            if (!filters.IncludeInactivated)
            {
                queryable = queryable.Where(company =>
                    !company.Inactivated);
            }

            if (!string.IsNullOrWhiteSpace(filters.Name))
            {
                queryable = queryable.Where(company =>
                    EF.Functions.Like(company.CorporateName, $"%{filters.Name}%") ||
                    EF.Functions.Like(company.BusinessName, $"%{filters.Name}%"));
            }

            if (!string.IsNullOrWhiteSpace(filters.RegistrationNumber))
            {
                queryable = queryable.Where(company =>
                    company.RegistrationNumber.Contains(filters.RegistrationNumber));
            }

            return await queryable.ToListAsync();
        }

        public async Task<Company> FindAsync(Guid id)
        {
            return await _companyRepository.FindAsync(id);
        }
    }
}
