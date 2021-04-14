using System;
using Restaurant.Core.Common;

namespace Restaurant.Core.QueryObjects
{
    public class DepartmentQuery : Query
    {
        public string Description { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
