using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Base;
using Restaurant.Core.Enumerators;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Api.DTOs.Menu
{
    [ModelMetadataType(typeof(Entity.Menu))]
    public class MenuPutDTO : PutDTO
    {
        public string Description { get; set; }
        public IEnumerable<MenuProductDTO> Products { get; set; }
        public DaysOfWeek? Availability { get; set; }
    }
}
