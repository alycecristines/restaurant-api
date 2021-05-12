using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Models.Common;
using Entity = Restaurant.Domain.Entities;

namespace Restaurant.Application.Models.Company
{
    [ModelMetadataType(typeof(Entity.Company))]
    public class CompanyCreateModel
    {
        public string CorporateName { get; set; }
        public string BusinessName { get; set; }
        public string RegistrationNumber { get; set; }
        public PhoneModel Phone { get; set; }
        public AddressModel Address { get; set; }
    }
}
