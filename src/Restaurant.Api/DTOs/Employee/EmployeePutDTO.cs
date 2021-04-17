using System;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Base;
using Entity = Restaurant.Core.Entities;

namespace Restaurant.Api.DTOs.Employee
{
    [ModelMetadataType(typeof(Entity.Employee))]
    public class EmployeePutDTO : PutDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
