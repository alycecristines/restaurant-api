using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Application.DTOs.Menu
{
    public class MenuProductDTO
    {
        [Required]
        public Guid? Id { get; set; }
    }
}
