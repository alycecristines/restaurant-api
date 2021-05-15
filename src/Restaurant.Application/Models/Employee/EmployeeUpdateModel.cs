using System;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Models.Base;
using Entity = Restaurant.Domain.Entities;

namespace Restaurant.Application.Models.Employee
{
    [ModelMetadataType(typeof(Entity.Employee))]
    public class EmployeeUpdateModel : ActivableUpdateModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
