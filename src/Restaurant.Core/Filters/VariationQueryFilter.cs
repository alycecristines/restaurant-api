using System;
using Restaurant.Core.Common;

namespace Restaurant.Core.QueryObjects
{
    public class VariationQueryFilter : QueryFilter
    {
        public string Description { get; set; }
        public Guid? ProductId { get; set; }
    }
}
