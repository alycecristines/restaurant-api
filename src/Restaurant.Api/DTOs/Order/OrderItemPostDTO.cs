using System;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.ValueObjects;

namespace Restaurant.Api.DTOs.Order
{
    [ModelMetadataType(typeof(OrderItem))]
    public class OrderItemPostDTO
    {
        public Guid? ProductId { get; set; }
        public Guid? VariationId { get; set; }
    }
}
