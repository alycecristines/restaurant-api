using System;
using System.Linq;
using Restaurant.Core.Entities;

namespace Restaurant.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        void Insert(Employee entity);
        IQueryable<Employee> GetAll();
        Employee Get(Guid id);
        void SaveChanges();
    }
}
