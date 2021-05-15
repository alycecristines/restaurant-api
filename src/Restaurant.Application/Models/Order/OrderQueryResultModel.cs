using System;
using System.Collections.Generic;
using Restaurant.Application.Models.Company;

namespace Restaurant.Application.Models.Order
{
    public class OrderQueryResultModel
    {
        public DateTime CreatedAt { get; set; }
        public IEnumerable<CompanyResponseModel> Companies { get; set; }
    }
}
