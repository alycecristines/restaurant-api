using System;
using System.Linq;
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

        public void Insert(Company entity)
        {
            _dbContext.Companies.Add(entity);
        }

        public IQueryable<Company> GetAll()
        {
            return _dbContext.Companies.AsQueryable();
        }

        public Company Get(Guid id)
        {
            return _dbContext.Companies.Find(id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
