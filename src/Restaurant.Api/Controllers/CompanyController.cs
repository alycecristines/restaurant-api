using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Company;
using Restaurant.Core.Services.Base;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;
using Restaurant.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Infrastructure.Identity.Constants;

namespace Restaurant.Api.Controllers
{
    [Route("api/companies")]
    [Authorize(Roles = RoleConstants.Administrator)]
    public class CompanyController : ApiControllerBase<Company, CompanyPostDTO, CompanyPutDTO, CompanyResponseDTO, CompanyQueryFilter>
    {
        public CompanyController(ICompanyService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
