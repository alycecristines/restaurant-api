using System;
using Restaurant.Domain.QueryFilters.Base;

namespace Restaurant.Domain.QueryFilters
{
    public class VariationQueryFilter : QueryFilter
    {
        public string Description { get; set; }
        public Guid? ProductId { get; set; }
    }
}
