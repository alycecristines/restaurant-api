using System;

namespace Restaurant.Application.QueryParams
{
    public class DepartmentQueryParams
    {
        public bool IncludeInactive { get; set; }
        public string Description { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
