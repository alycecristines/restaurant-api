using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.Models.Common
{
    [ModelMetadataType(typeof(Phone))]
    public class PhoneModel
    {
        public string AreaCode { get; set; }
        public string Number { get; set; }
    }
}
