using Restaurant.Core.Entities;

namespace Restaurant.Core.Interfaces
{
    public interface IDepartmentRepository
    {
        void Insert(Department entity);
        void SaveChanges();
    }
}
