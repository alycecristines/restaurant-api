using System.Threading.Tasks;
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

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
