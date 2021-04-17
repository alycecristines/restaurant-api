using Restaurant.Core.QueryFilters.Base;

namespace Restaurant.Core.QueryFilters
{
    public class CompanyQueryFilter : QueryFilter
    {
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
