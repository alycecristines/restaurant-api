using System;

namespace Restaurant.Application.QueryParams
{
    public class EmployeeQueryParams
    {
        public bool IncludeInactivated { get; set; }
        public bool IncludeDeleted { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
