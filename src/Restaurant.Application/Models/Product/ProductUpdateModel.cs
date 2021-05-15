using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Models.Base;
using Entity = Restaurant.Domain.Entities;

namespace Restaurant.Application.Models.Product
{
    [ModelMetadataType(typeof(Entity.Product))]
    public class ProductUpdateModel : ActivableUpdateModel
    {
        public string Description { get; set; }
    }
}
