using Restaurant.Core.QueryObjects;
using Restaurant.Core.Entities;

namespace Restaurant.Core.Interfaces
{
    public interface IDepartmentService : IService<Department, DepartmentQueryFilter>
    {
    }
}
