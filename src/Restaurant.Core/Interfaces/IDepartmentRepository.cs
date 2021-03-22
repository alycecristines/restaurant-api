using System;
using System.Linq;
using Restaurant.Core.Entities;

namespace Restaurant.Core.Interfaces
{
    public interface IDepartmentRepository
    {
        void Insert(Department entity);
        IQueryable<Department> GetAll();
        Department Get(Guid id);
        void SaveChanges();
    }
}
