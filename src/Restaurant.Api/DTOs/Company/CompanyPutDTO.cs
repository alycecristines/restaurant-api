using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Base;
using Restaurant.Api.DTOs.Common;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Api.DTOs.Company
{
    [ModelMetadataType(typeof(Entity.Company))]
    public class CompanyPutDTO : PutDTO
    {
        public string CorporateName { get; set; }
        public string BusinessName { get; set; }
        public PhoneDTO Phone { get; set; }
        public AddressDTO Address { get; set; }
    }
}
