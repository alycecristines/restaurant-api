using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Product;
using Restaurant.Core.Services.Base;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;
using Restaurant.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Infrastructure.Identity.Constants;

namespace Restaurant.Api.Controllers
{
    [Route("api/products")]
    [Authorize(Roles = RoleConstants.Administrator)]
    public class ProductController : ApiControllerBase<Product, ProductPostDTO, ProductPutDTO, ProductResponseDTO, ProductQueryFilter>
    {
        public ProductController(IProductService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
