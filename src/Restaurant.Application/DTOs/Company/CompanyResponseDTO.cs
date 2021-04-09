using Restaurant.Application.DTOs.Common;

namespace Restaurant.Application.DTOs.Company
{
    public class CompanyResponseDTO
    {
        public string Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactivated { get; set; }
        public string CorporateName { get; set; }
        public string BusinessName { get; set; }
        public string RegistrationNumber { get; set; }
        public PhoneDTO Phone { get; set; }
        public AddressDTO Address { get; set; }
    }
}
