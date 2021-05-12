using System;
using System.Collections.Generic;
using Restaurant.Domain.Entities;
using Restaurant.Domain.QueryFilters;
using Restaurant.Domain.Repositories.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Extensions;

namespace Restaurant.Domain.Services
{
    public class CompanyDomainService : ICompanyDomainService
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyDomainService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> CreateAsync(Company newCompany)
        {
            await ValidateCreationAsync(newCompany);
            _companyRepository.Add(newCompany);
            await _companyRepository.SaveChangesAsync();
            return newCompany;
        }

        private async Task ValidateCreationAsync(Company newCompany)
        {
            if (!await Exists(newCompany.RegistrationNumber)) return;

            var message = $"Já existe uma empresa cadastrada com o CNPJ '{newCompany.RegistrationNumber}'.";
            throw new DomainException(message);
        }

        private async Task<bool> Exists(string registrationNumber)
        {
            return await _companyRepository.Queryable()
                .AnyAsync(company => company.RegistrationNumber == registrationNumber);
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
            return await _companyRepository.Queryable()
                .WhereFor(!filters.IncludeInactivated, company => !company.Inactivated)
                .WhereFor(filters.Name, company => EF.Functions.Like(company.CorporateName, $"%{filters.Name}%")
                    || EF.Functions.Like(company.BusinessName, $"%{filters.Name}%"))
                .WhereFor(filters.RegistrationNumber, company => company.RegistrationNumber.Contains(filters.RegistrationNumber))
                .ToListAsync();
        }

        public async Task<Company> FindAsync(Guid id)
        {
            return await _companyRepository.FindAsync(id);
        }
    }
}
