using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Application.DTOs.Request
{
    public class DepartmentPostDTO
    {
        [Required]
        public Guid? CompanyId { get; set; }

        [Required, StringLength(50)]
        public string Description { get; set; }
    }
}
