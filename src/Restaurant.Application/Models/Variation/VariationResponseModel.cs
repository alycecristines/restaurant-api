using System;
using Restaurant.Application.Models.Base;

namespace Restaurant.Application.Models.Variation
{
    public class VariationResponseModel : ResponseModel
    {
        public string Description { get; set; }
        public Guid ProductId { get; set; }
    }
}
