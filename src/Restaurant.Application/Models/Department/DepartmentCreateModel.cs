using System;
using Microsoft.AspNetCore.Mvc;
using Entity = Restaurant.Domain.Entities;

namespace Restaurant.Application.Models.Department
{
    [ModelMetadataType(typeof(Entity.Department))]
    public class DepartmentCreateModel
    {
        public string Description { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
