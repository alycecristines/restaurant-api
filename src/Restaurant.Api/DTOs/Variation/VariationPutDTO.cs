using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Base;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Api.DTOs.Variation
{
    [ModelMetadataType(typeof(Entity.Variation))]
    public class VariationPutDTO : PutDTO
    {
        public string Description { get; set; }
    }
}
