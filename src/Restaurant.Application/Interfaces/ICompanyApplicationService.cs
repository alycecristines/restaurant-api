using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Application.Models.Company;
using Restaurant.Domain.QueryFilters;

namespace Restaurant.Application.Interfaces
{
    public interface ICompanyApplicationService
    {
        Task<CompanyResponseModel> CreateAsync(CompanyCreateModel model);
        Task<CompanyResponseModel> UpdateAsync(Guid id, CompanyUpdateModel model);
        Task<IEnumerable<CompanyResponseModel>> FindAllAsync(CompanyQueryFilter filters);
        Task<CompanyResponseModel> FindAsync(Guid id);
    }
}
