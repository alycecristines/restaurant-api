using System.Collections.Generic;
using Restaurant.Application.Models.Base;
using Restaurant.Application.Models.Common;
using Restaurant.Application.Models.Department;

namespace Restaurant.Application.Models.Company
{
    public class CompanyResponseModel : ResponseModel
    {
        public string CorporateName { get; set; }
        public string BusinessName { get; set; }
        public string RegistrationNumber { get; set; }
        public PhoneModel Phone { get; set; }
        public AddressModel Address { get; set; }
        public IEnumerable<DepartmentResponseModel> Departments { get; set; }
    }
}
