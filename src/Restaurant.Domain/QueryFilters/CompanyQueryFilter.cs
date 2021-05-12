using Restaurant.Domain.QueryFilters.Base;

namespace Restaurant.Domain.QueryFilters
{
    public class CompanyQueryFilter : QueryFilter
    {
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
