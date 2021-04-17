using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Variation;
using Restaurant.Core.Services.Base;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;
using Restaurant.Api.Controllers.Base;

namespace Restaurant.Api.Controllers
{
    [Route("api/variations")]
    public class VariationController : ApiController<Variation, VariationPostDTO,
        VariationPutDTO, VariationResponseDTO, VariationQueryFilter>
    {
        public VariationController(IVariationService service,
            IMapper mapper) : base(service, mapper)
        {
        }
    }
}
