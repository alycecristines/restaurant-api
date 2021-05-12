using System;
using System.Collections.Generic;
using Restaurant.Domain.Entities;

namespace Restaurant.Domain.QueryResults
{
    public class OrderQueryResult
    {
        public DateTime CreatedAt { get; set; }
        public IEnumerable<Company> Companies { get; set; }
    }
}
