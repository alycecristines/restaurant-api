using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Base;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Api.DTOs.Product
{
    [ModelMetadataType(typeof(Entity.Product))]
    public class ProductPutDTO : PutDTO
    {
        public string Description { get; set; }
    }
}
