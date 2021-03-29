using System;
using Microsoft.AspNetCore.Mvc;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Api.DTOs.Department
{
    [ModelMetadataType(typeof(Entity.Department))]
    public class DepartmentPostDTO
    {
        public string Description { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
