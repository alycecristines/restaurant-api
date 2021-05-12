using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.QueryFilters;

namespace Restaurant.Domain.Interfaces
{
    public interface ICompanyDomainService
    {
        Task<Company> CreateAsync(Company newCompany);
        Task<Company> UpdateAsync(Guid id, Company newCompany);
        Task<IEnumerable<Company>> FindAllAsync(CompanyQueryFilter filters);
        Task<Company> FindAsync(Guid id);
    }
}
