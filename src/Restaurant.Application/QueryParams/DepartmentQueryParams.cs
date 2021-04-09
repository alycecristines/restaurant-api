using System;

namespace Restaurant.Application.QueryParams
{
    public class DepartmentQueryParams
    {
        public bool IncludeInactivated { get; set; }
        public bool IncludeDeleted { get; set; }
        public string Description { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
