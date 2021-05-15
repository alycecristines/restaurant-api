using System;
using Restaurant.Domain.QueryFilters.Base;

namespace Restaurant.Domain.QueryFilters
{
    public class ProductQueryFilter : QueryFilter
    {
        public string Description { get; set; }
        public Guid? MenuId { get; set; }
    }
}
