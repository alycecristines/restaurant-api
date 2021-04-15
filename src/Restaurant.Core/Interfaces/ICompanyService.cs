using Restaurant.Core.Entities;
using Restaurant.Core.QueryObjects;

namespace Restaurant.Core.Interfaces
{
    public interface ICompanyService : IService<Company, CompanyQueryFilter>
    {
    }
}
