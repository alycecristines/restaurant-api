using Microsoft.AspNetCore.Mvc;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Application.DTOs.Department
{
    [ModelMetadataType(typeof(Entity.Department))]
    public class DepartmentPutDTO
    {
        public string Description { get; set; }
    }
}
