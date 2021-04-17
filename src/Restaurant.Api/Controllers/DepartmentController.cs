using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.Controllers.Base;
using Restaurant.Api.DTOs.Department;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;
using Restaurant.Core.QueryFilters;

namespace Restaurant.Api.Controllers
{
    [Route("api/departments")]
    public class DepartmentController : ApiController<Department, DepartmentPostDTO,
        DepartmentPutDTO, DepartmentResponseDTO, DepartmentQueryFilter>
    {
        public DepartmentController(IDepartmentService service,
            IMapper mapper) : base(service, mapper)
        {
        }
    }
}
