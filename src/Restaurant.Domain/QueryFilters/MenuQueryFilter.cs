using Restaurant.Domain.QueryFilters.Base;

namespace Restaurant.Domain.QueryFilters
{
    public class MenuQueryFilter : QueryFilter
    {
        public string Description { get; set; }
    }
}
