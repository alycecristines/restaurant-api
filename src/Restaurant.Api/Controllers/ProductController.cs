using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Product;
using Restaurant.Core.Interfaces;
using Restaurant.Core.QueryFilters;
using Restaurant.Core.Entities;
using Restaurant.Api.Controllers.Base;

namespace Restaurant.Api.Controllers
{
    [Route("api/products")]
    public class ProductController : ApiController<Product, ProductPostDTO,
        ProductPutDTO, ProductResponseDTO, ProductQueryFilter>
    {
        public ProductController(IProductService service,
            IMapper mapper) : base(service, mapper)
        {
        }
    }
}
