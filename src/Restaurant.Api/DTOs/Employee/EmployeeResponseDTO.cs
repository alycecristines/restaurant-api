using System;
using Restaurant.Api.DTOs.Base;

namespace Restaurant.Api.DTOs.Employee
{
    public class EmployeeResponseDTO : ResponseDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
