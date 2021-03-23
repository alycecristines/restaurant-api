using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Application.DTOs.Request
{
    public class EmployeePostPutDTO
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Required]
        public Guid? DepartmentId { get; set; }
    }
}
