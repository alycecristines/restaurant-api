using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;
using Restaurant.Infrastructure.Data;

namespace Restaurant.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDataContext _dbContext;

        public DepartmentRepository(ApplicationDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Insert(Department entity)
        {
            _dbContext.Departments.Add(entity);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
