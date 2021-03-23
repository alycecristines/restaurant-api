using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;
using Restaurant.Infrastructure.Data;

namespace Restaurant.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDataContext _dbContext;

        public EmployeeRepository(ApplicationDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Insert(Employee entity)
        {
            _dbContext.Employees.Add(entity);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
