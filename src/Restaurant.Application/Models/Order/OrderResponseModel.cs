using System.Collections.Generic;
using Restaurant.Application.Models.Base;

namespace Restaurant.Application.Models.Order
{
    public class OrderResponseModel : ResponseModel
    {
        public IEnumerable<OrderItemResponseModel> Items { get; set; }
    }
}
