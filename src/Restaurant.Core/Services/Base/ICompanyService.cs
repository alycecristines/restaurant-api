using Restaurant.Core.Entities;
using Restaurant.Core.QueryFilters;

namespace Restaurant.Core.Services.Base
{
    public interface ICompanyService : IService<Company, CompanyQueryFilter>
    {
    }
}
