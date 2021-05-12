using System;
using Restaurant.Domain.QueryFilters.Base;

namespace Restaurant.Domain.QueryFilters
{
    public class DepartmentQueryFilter : QueryFilter
    {
        public string Description { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
