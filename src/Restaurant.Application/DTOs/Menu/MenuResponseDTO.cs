using System;
using Restaurant.Core.Enumerators;

namespace Restaurant.Application.DTOs.Menu
{
    public class MenuResponseDTO
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public string Description { get; set; }
        public DaysOfWeek Availability { get; set; }
    }
}
