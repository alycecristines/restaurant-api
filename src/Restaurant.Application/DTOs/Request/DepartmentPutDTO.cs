using System.ComponentModel.DataAnnotations;

namespace Restaurant.Application.DTOs.Request
{
    public class DepartmentPutDTO
    {
        [Required, StringLength(50)]
        public string Description { get; set; }
    }
}
