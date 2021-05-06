using Restaurant.Api.DTOs.Base;
using Restaurant.Api.DTOs.Company;

namespace Restaurant.Api.DTOs.Department
{
    public class DepartmentResponseDTO : ResponseDTO
    {
        public string Description { get; set; }
        public CompanyResponseDTO Company { get; set; }
    }
}
