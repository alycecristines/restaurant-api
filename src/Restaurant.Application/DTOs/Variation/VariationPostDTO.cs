using System;
using Microsoft.AspNetCore.Mvc;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Application.DTOs.Variation
{
    [ModelMetadataType(typeof(Entity.Variation))]
    public class VariationPostDTO
    {
        public string Description { get; set; }
        public Guid? ProductId { get; set; }
    }
}
