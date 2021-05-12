using System;

namespace Restaurant.Domain.QueryFilters
{
    public class OrderQueryFilter
    {
        public DateTime CreatedAt { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
