using System;
using Restaurant.Core.Common;

namespace Restaurant.Core.QueryFilters
{
    public class VariationQueryFilter : QueryFilter
    {
        public string Description { get; set; }
        public Guid? ProductId { get; set; }
    }
}
