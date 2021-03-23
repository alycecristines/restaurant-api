using Restaurant.Core.Entities;

namespace Restaurant.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        void Insert(Employee entity);
        void SaveChanges();
    }
}
