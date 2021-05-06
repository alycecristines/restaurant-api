using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Api.DTOs.Order
{
    [ModelMetadataType(typeof(Entity.Order))]
    public class OrderPostDTO
    {
        public IEnumerable<OrderItemPostDTO> Items { get; set; }
    }
}
