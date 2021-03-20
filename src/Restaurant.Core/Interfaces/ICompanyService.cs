using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Core.Entities;

namespace Restaurant.Core.Interfaces
{
    public interface ICompanyService
    {
        Task Insert(Company newEntity);
        Task<IEnumerable<Company>> GetAsync();
        Task<IEnumerable<Company>> GetAsync(string nameOrRegistrationNumber);
        Task<Company> GetAsync(Guid id);
        Task Update(Company updatedEntity);
        Task Delete(Guid id);
    }
}
