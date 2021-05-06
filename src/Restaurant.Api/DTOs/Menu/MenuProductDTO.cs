using System;
using System.ComponentModel.DataAnnotations;
using Restaurant.Core.Localization;

namespace Restaurant.Api.DTOs.Menu
{
    public class MenuProductDTO
    {
        [Required(ErrorMessage = PortugueseDataAnnotationErrorDescriber.Required)]
        public Guid? Id { get; set; }
    }
}
