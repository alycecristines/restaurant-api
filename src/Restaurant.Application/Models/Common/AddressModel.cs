using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.Models.Common
{
    [ModelMetadataType(typeof(Address))]
    public class AddressModel
    {
        public string Street { get; set; }
        public string Secondary { get; set; }
        public string BuildingNumber { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
