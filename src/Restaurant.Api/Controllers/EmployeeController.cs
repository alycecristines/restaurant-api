using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Services.Base;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;
using Restaurant.Api.Controllers.Base;
using Restaurant.Api.DTOs.Employee;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Infrastructure.Identity.Constants;

namespace Restaurant.Api.Controllers
{
    [Route("api/employees")]
    [Authorize(Roles = RoleConstants.Administrator)]
    public class EmployeeController : ApiControllerBase<Employee, EmployeePostDTO, EmployeePutDTO, EmployeeResponseDTO, EmployeeQueryFilter>
    {
        public EmployeeController(IEmployeeService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
