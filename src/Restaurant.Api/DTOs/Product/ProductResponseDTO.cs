using System;
using Restaurant.Api.DTOs.Base;

namespace Restaurant.Api.DTOs.Product
{
    public class ProductResponseDTO : ResponseDTO
    {
        public string Description { get; set; }
    }
}
