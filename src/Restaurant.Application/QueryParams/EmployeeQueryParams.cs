using System;

namespace Restaurant.Application.QueryParams
{
    public class EmployeeQueryParams
    {
        public bool IncludeInactive { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
