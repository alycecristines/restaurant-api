using System;

namespace Restaurant.Application.DTOs.Employee
{
    public class EmployeeResponseDTO
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactivated { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
