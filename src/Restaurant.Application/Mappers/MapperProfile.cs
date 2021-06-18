using AutoMapper;
using Restaurant.Application.Models;
using Restaurant.Application.Models.Common;
using Restaurant.Application.Models.Company;
using Restaurant.Application.Models.Department;
using Restaurant.Application.Models.Employee;
using Restaurant.Application.Models.Order;
using Restaurant.Application.Models.Product;
using Restaurant.Application.Models.Variation;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Entities.Base;
using Restaurant.Domain.QueryResults;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CompanyCreateModel, Company>();
            CreateMap<CompanyUpdateModel, Company>();
            CreateMap<Company, CompanyResponseModel>();

            CreateMap<DepartmentCreateModel, Department>();
            CreateMap<DepartmentUpdateModel, Department>();
            CreateMap<Department, DepartmentResponseModel>();

            CreateMap<EmployeeCreateModel, Employee>();
            CreateMap<EmployeeUpdateModel, Employee>();
            CreateMap<Employee, EmployeeResponseModel>();

            CreateMap<ProductCreateModel, Product>();
            CreateMap<ProductUpdateModel, Product>();
            CreateMap<Product, ProductResponseModel>();

            CreateMap<VariationCreateModel, Variation>();
            CreateMap<VariationUpdateModel, Variation>();
            CreateMap<Variation, VariationResponseModel>();

            CreateMap<OrderCreateModel, Order>();
            CreateMap<Order, OrderResponseModel>();
            CreateMap<OrderQueryResult, OrderQueryResultModel>();
            CreateMap<OrderItem, OrderItemResponseModel>();
            CreateMap<OrderItemCreateModel, OrderItem>()
                .ForPath(entity => entity.Product.Id, config => config.MapFrom(dto => dto.ProductId))
                .ForPath(entity => entity.Variation.Id, config => config.MapFrom(dto => dto.VariationId));

            CreateMap<PhoneModel, Phone>().ReverseMap();
            CreateMap<AddressModel, Address>().ReverseMap();

            CreateMap<User, UserResponseModel>();
            CreateMap<UserToken, UserTokenResponseModel>();
        }
    }
}
