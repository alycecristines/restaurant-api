using System;
using Microsoft.AspNetCore.Mvc;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Application.DTOs.Employee
{
    [ModelMetadataType(typeof(Entity.Employee))]
    public class EmployeePostDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
