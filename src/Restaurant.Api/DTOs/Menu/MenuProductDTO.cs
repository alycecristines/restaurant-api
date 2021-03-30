using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Api.DTOs.Menu
{
    public class MenuProductDTO
    {
        [Required]
        public Guid? Id { get; set; }
    }
}
