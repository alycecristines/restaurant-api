using System;

namespace Restaurant.Api.DTOs.Employee
{
    public class EmployeeResponseDTO
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }
    }
}