using System;
using Restaurant.Core.Common;

namespace Restaurant.Core.QueryObjects
{
    public class VariationQuery : Query
    {
        public string Description { get; set; }
        public Guid? ProductId { get; set; }
    }
}
