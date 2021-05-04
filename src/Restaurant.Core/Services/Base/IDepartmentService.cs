using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;

namespace Restaurant.Core.Services.Base
{
    public interface IDepartmentService : IService<Department, DepartmentQueryFilter>
    {
    }
}