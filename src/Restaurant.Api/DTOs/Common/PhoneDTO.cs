using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.ValueObjects;

namespace Restaurant.Api.DTOs.Common
{
    [ModelMetadataType(typeof(Phone))]
    public class PhoneDTO
    {
        public string AreaCode { get; set; }
        public string Number { get; set; }
    }
}
