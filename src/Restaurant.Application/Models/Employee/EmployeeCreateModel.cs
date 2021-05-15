using System;
using Microsoft.AspNetCore.Mvc;
using Entity = Restaurant.Domain.Entities;

namespace Restaurant.Application.Models.Employee
{
    [ModelMetadataType(typeof(Entity.Employee))]
    public class EmployeeCreateModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
