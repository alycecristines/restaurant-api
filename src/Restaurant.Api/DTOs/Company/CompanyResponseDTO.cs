using Restaurant.Api.DTOs.Base;
using Restaurant.Api.DTOs.Common;

namespace Restaurant.Api.DTOs.Company
{
    public class CompanyResponseDTO : ResponseDTO
    {
        public string CorporateName { get; set; }
        public string BusinessName { get; set; }
        public string RegistrationNumber { get; set; }
        public PhoneDTO Phone { get; set; }
        public AddressDTO Address { get; set; }
    }
}
