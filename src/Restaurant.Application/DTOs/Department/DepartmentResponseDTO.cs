using System;

namespace Restaurant.Application.DTOs.Department
{
    public class DepartmentResponseDTO
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactivated { get; set; }
        public string Description { get; set; }
        public Guid CompanyId { get; set; }
    }
}
