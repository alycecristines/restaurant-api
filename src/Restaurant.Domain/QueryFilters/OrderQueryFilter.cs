using System;

namespace Restaurant.Domain.QueryFilters
{
    public class OrderQueryFilter
    {
        public bool IncludePrinted { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
