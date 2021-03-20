using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Core.Entities;

namespace Restaurant.Core.Interfaces
{
    public interface ICompanyRepository
    {
        void Insert(Company entity);
        Task<IEnumerable<Company>> GetAsync();
        Task<IEnumerable<Company>> GetAsync(string nameOrRegistrationNumber);
        Task<Company> GetAsync(Guid id);
        void Delete(Company entity);
        void Update(Company entity);
        Task SaveChangesAsync();
    }
}
