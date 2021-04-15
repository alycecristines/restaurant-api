using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;

namespace Restaurant.Core.Interfaces
{
    public interface IDepartmentService : IService<Department, DepartmentQueryFilter>
    {
    }
}
