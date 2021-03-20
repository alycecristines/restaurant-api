using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;
using Restaurant.Infrastructure.Data;

namespace Restaurant.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDataContext _dbContext;

        public CompanyRepository(ApplicationDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Company Insert(Company entity)
        {
            return _dbContext.Companies.Add(entity).Entity;
        }

        public async Task<IEnumerable<Company>> GetAsync()
        {
            return await _dbContext.Companies.Where(entity =>
                !entity.DeletedAt.HasValue
            ).ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetAsync(string nameOrRegistrationNumber)
        {
            return await _dbContext.Companies.Where(entity =>
                (entity.CorporateName.Contains(nameOrRegistrationNumber) ||
                entity.BusinessName.Contains(nameOrRegistrationNumber) ||
                entity.RegistrationNumber.Contains(nameOrRegistrationNumber)) &&
                !entity.DeletedAt.HasValue
            ).ToListAsync();
        }

        public async Task<Company> GetAsync(Guid id)
        {
            return await _dbContext.Companies.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
