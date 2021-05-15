using System;
using System.Collections.Generic;
using Restaurant.Application.Models.Base;

namespace Restaurant.Application.Models.Order
{
    public class OrderResponseModel : ResponseModel
    {
        public DateTime CreatedAt { get; set; }
        public bool Printed { get; set; }
        public IEnumerable<OrderItemResponseModel> Items { get; set; }
    }
}
