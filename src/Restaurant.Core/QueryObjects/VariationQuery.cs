using System;
using Restaurant.Core.QueryObjects.Base;

namespace Restaurant.Core.QueryObjects
{
    public class VariationQuery : Query
    {
        public string Description { get; set; }
        public Guid? ProductId { get; set; }
    }
}
