using System;
using Restaurant.Api.DTOs.Base;
using Restaurant.Core.Enumerators;

namespace Restaurant.Api.DTOs.Menu
{
    public class MenuResponseDTO : ResponseDTO
    {
        public string Description { get; set; }
        public DaysOfWeek Availability { get; set; }
    }
}
