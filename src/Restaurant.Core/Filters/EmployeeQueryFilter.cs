using System;
using Restaurant.Core.Common;

namespace Restaurant.Core.QueryObjects
{
    public class EmployeeQueryFilter : QueryFilter
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
