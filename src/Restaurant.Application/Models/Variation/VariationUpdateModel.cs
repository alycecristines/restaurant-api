using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Models.Base;
using Entity = Restaurant.Domain.Entities;

namespace Restaurant.Application.Models.Variation
{
    [ModelMetadataType(typeof(Entity.Variation))]
    public class VariationUpdateModel : ActivableUpdateModel
    {
        public string Description { get; set; }
    }
}
