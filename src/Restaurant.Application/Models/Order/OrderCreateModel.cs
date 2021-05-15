using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Entity = Restaurant.Domain.Entities;

namespace Restaurant.Application.Models.Order
{
    [ModelMetadataType(typeof(Entity.Order))]
    public class OrderCreateModel
    {
        public IEnumerable<OrderItemCreateModel> Items { get; set; }
    }
}
