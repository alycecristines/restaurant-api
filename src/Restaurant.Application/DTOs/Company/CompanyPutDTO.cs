using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOs.Common;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Application.DTOs.Company
{
    [ModelMetadataType(typeof(Entity.Company))]
    public class CompanyPutDTO
    {
        public bool Inactivated { get; set; }
        public string CorporateName { get; set; }
        public string BusinessName { get; set; }
        public PhoneDTO Phone { get; set; }
        public AddressDTO Address { get; set; }
    }
}
