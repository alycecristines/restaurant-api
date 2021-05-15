using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Models.Base;
using Restaurant.Application.Models.Common;
using Entity = Restaurant.Domain.Entities;

namespace Restaurant.Application.Models.Company
{
    [ModelMetadataType(typeof(Entity.Company))]
    public class CompanyUpdateModel : ActivableUpdateModel
    {
        public string CorporateName { get; set; }
        public string BusinessName { get; set; }
        public PhoneModel Phone { get; set; }
        public AddressModel Address { get; set; }
    }
}
