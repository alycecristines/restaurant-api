using System;
using System.Collections.Generic;
using Restaurant.Application.Models.Base;
using Restaurant.Application.Models.Company;
using Restaurant.Application.Models.Employee;

namespace Restaurant.Application.Models.Department
{
    public class DepartmentResponseModel : ResponseModel
    {
        public string Description { get; set; }
        public Guid CompanyId { get; set; }
        public CompanyResponseModel Company { get; set; }
        public IEnumerable<EmployeeResponseModel> Employees { get; set; }
    }
}
