using System;
using Restaurant.Core.QueryFilters.Base;

namespace Restaurant.Core.QueryFilters
{
    public class ProductQueryFilter : QueryFilter
    {
        public string Description { get; set; }
        public Guid? MenuId { get; set; }
    }
}
