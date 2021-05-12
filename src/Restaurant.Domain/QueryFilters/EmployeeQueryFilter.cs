using System;
using Restaurant.Domain.QueryFilters.Base;

namespace Restaurant.Domain.QueryFilters
{
    public class EmployeeQueryFilter : QueryFilter
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
