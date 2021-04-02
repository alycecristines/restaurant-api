using System;
using System.Collections.Generic;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Interfaces
{
    public interface ICompanyService
    {
        Company Insert(Company newCompany);
        IEnumerable<Company> GetAll(CompanyQueryParams queryParams);
        Company Get(Guid id);
        Company Update(Guid id, Company newCompany);
        void Delete(Guid id);
    }
}
