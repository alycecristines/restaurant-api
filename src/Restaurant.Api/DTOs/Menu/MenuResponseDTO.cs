using System;
using Restaurant.Core.Enumerators;

namespace Restaurant.Api.DTOs.Menu
{
    public class MenuResponseDTO
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactivated { get; set; }
        public string Description { get; set; }
        public DaysOfWeek Availability { get; set; }
    }
}
