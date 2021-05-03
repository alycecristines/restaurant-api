using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.Controllers.Base;
using Restaurant.Api.DTOs.Department;
using Restaurant.Core.Entities;
using Restaurant.Core.Services.Base;
using Restaurant.Core.QueryFilters;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Infrastructure.Identity.Constants;

namespace Restaurant.Api.Controllers
{
    [Route("api/departments")]
    [Authorize(Roles = RoleConstants.Administrator)]
    public class DepartmentController : ApiControllerBase<Department, DepartmentPostDTO, DepartmentPutDTO, DepartmentResponseDTO, DepartmentQueryFilter>
    {
        public DepartmentController(IDepartmentService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
