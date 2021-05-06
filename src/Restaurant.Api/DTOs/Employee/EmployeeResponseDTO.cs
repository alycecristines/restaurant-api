using Restaurant.Api.DTOs.Base;
using Restaurant.Api.DTOs.Department;

namespace Restaurant.Api.DTOs.Employee
{
    public class EmployeeResponseDTO : ResponseDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DepartmentResponseDTO Department { get; set; }
    }
}
