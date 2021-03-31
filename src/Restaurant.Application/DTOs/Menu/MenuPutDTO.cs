using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Enumerators;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Application.DTOs.Menu
{
    [ModelMetadataType(typeof(Entity.Menu))]
    public class MenuPutDTO
    {
        public string Description { get; set; }
        public IEnumerable<MenuProductDTO> Products { get; set; }
        public DaysOfWeek? Availability { get; set; }
    }
}
