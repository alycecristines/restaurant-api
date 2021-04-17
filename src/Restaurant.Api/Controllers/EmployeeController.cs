using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Interfaces;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;
using Restaurant.Api.Controllers.Base;
using Restaurant.Api.DTOs.Employee;

namespace Restaurant.Api.Controllers
{
    [Route("api/employees")]
    public class EmployeeController : ApiController<Employee, EmployeePostDTO,
        EmployeePutDTO, EmployeeResponseDTO, EmployeeQueryFilter>
    {
        public EmployeeController(IEmployeeService service,
            IMapper mapper) : base(service, mapper)
        {
        }
    }
}
