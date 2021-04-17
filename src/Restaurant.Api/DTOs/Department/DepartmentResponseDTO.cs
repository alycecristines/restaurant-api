using System;
using Restaurant.Api.DTOs.Base;

namespace Restaurant.Api.DTOs.Department
{
    public class DepartmentResponseDTO : ResponseDTO
    {
        public string Description { get; set; }
        public Guid CompanyId { get; set; }
    }
}
