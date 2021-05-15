using System;
using Microsoft.AspNetCore.Mvc;
using Entity = Restaurant.Domain.Entities;

namespace Restaurant.Application.Models.Variation
{
    [ModelMetadataType(typeof(Entity.Variation))]
    public class VariationCreateModel
    {
        public string Description { get; set; }
        public Guid? ProductId { get; set; }
    }
}
