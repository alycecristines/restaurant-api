using System;

namespace Restaurant.Application.QueryParams
{
    public class VariationQueryParams
    {
        public bool IncludeInactive { get; set; }
        public string Description { get; set; }
        public Guid? ProductId { get; set; }
    }
}
