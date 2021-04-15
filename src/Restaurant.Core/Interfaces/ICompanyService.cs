using Restaurant.Core.Entities;
using Restaurant.Core.QueryFilters;

namespace Restaurant.Core.Interfaces
{
    public interface ICompanyService : IService<Company, CompanyQueryFilter>
    {
    }
}
