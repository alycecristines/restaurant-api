using System;
using Restaurant.Core.QueryFilters.Base;

namespace Restaurant.Core.QueryFilters
{
    public class OrderQueryFilter : QueryFilter
    {
        public DateTime CreatedAt { get; set; }
    }
}
