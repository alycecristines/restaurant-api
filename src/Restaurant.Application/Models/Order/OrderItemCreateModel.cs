using System;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.Models.Order
{
    [ModelMetadataType(typeof(OrderItem))]
    public class OrderItemCreateModel
    {
        public Guid? ProductId { get; set; }
        public Guid? VariationId { get; set; }
    }
}
