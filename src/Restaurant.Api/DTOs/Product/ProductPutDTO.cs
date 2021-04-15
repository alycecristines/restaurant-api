using Microsoft.AspNetCore.Mvc;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Api.DTOs.Product
{
    [ModelMetadataType(typeof(Entity.Product))]
    public class ProductPutDTO
    {
        public bool Inactivated { get; set; }
        public string Description { get; set; }
    }
}