using System;

namespace Restaurant.Application.DTOs.Response
{
    public class DepartmentResponseDTO
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public string Description { get; set; }
        public Guid CompanyId { get; set; }
    }
}
