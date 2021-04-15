using Microsoft.AspNetCore.Mvc;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Api.DTOs.Variation
{
    [ModelMetadataType(typeof(Entity.Variation))]
    public class VariationPutDTO
    {
        public bool Inactivated { get; set; }
        public string Description { get; set; }
    }
}
