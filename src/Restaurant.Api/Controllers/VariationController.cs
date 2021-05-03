using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Variation;
using Restaurant.Core.Services.Base;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;
using Restaurant.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Infrastructure.Identity.Constants;

namespace Restaurant.Api.Controllers
{
    [Route("api/variations")]
    [Authorize(Roles = RoleConstants.Administrator)]
    public class VariationController : ApiControllerBase<Variation, VariationPostDTO, VariationPutDTO, VariationResponseDTO, VariationQueryFilter>
    {
        public VariationController(IVariationService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
