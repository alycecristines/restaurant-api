using System;
using Restaurant.Core.QueryFilters.Base;

namespace Restaurant.Core.QueryFilters
{
    public class DepartmentQueryFilter : QueryFilter
    {
        public string Description { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
