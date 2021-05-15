using System;
using System.ComponentModel.DataAnnotations;
using Restaurant.Domain.Localization;

namespace Restaurant.Application.Models.Menu
{
    public class MenuProductModel
    {
        [Required(ErrorMessage = PortugueseErrorDescriber.Required)]
        public Guid? Id { get; set; }
    }
}
