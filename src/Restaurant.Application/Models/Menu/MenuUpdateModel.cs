using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Models.Base;
using Restaurant.Domain.Enumerators;
using Entity = Restaurant.Domain.Entities;

namespace Restaurant.Application.Models.Menu
{
    [ModelMetadataType(typeof(Entity.Menu))]
    public class MenuUpdateModel : UpdateModel
    {
        public string Description { get; set; }
        public IEnumerable<MenuProductModel> Products { get; set; }
        public DaysOfWeek? Availability { get; set; }
    }
}
