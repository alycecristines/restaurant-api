using System;
using System.Collections.Generic;
using Restaurant.Application.Models.Base;
using Restaurant.Application.Models.Department;
using Restaurant.Application.Models.Order;

namespace Restaurant.Application.Models.Employee
{
    public class EmployeeResponseModel : ResponseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }
        public DepartmentResponseModel Department { get; set; }
        public IEnumerable<OrderResponseModel> Orders { get; set; }
    }
}
