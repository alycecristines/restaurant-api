using Microsoft.AspNetCore.Mvc;
using Entity = Restaurant.Domain.Entities;

namespace Restaurant.Application.Models.Product
{
    [ModelMetadataType(typeof(Entity.Product))]
    public class ProductCreateModel
    {
        public string Description { get; set; }
    }
}
