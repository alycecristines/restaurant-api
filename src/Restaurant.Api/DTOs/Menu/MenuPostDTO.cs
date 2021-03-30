using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Enums;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Api.DTOs.Menu
{
    [ModelMetadataType(typeof(Entity.Menu))]
    public class MenuPostDTO
    {
        public string Description { get; set; }
        public IEnumerable<MenuProductDTO> Products { get; set; }
        public DaysOfWeek? Availability { get; set; }
    }
}
