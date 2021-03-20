using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Core.Entities;

namespace Restaurant.Core.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> Insert(Company entity);
        Task<IEnumerable<Company>> GetAsync();
        Task<IEnumerable<Company>> GetAsync(string nameOrRegistrationNumber);
        Task<Company> GetAsync(Guid id);
    }
}
