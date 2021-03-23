using System;
using System.Linq;
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

        public IQueryable<Employee> GetAll()
        {
            return _dbContext.Employees.AsQueryable();
        }

        public Employee Get(Guid id)
        {
            return _dbContext.Employees.Find(id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
