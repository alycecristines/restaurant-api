using System;
using Restaurant.Core.Common;

namespace Restaurant.Core.QueryFilters
{
    public class DepartmentQueryFilter : QueryFilter
    {
        public string Description { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
