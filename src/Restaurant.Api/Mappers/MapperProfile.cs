using AutoMapper;
using Restaurant.Api.DTOs.Common;
using Restaurant.Api.DTOs.Company;
using Restaurant.Api.DTOs.Department;
using Restaurant.Api.DTOs.Employee;
using Restaurant.Api.DTOs.Menu;
using Restaurant.Api.DTOs.Product;
using Restaurant.Api.DTOs.Variation;
using Restaurant.Core.Entities;
using Restaurant.Core.ValueObjects;

namespace Restaurant.Api.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CompanyPostDTO, Company>();
            CreateMap<CompanyPutDTO, Company>();
            CreateMap<Company, CompanyResponseDTO>();

            CreateMap<DepartmentPostDTO, Department>();
            CreateMap<DepartmentPutDTO, Department>();
            CreateMap<Department, DepartmentResponseDTO>();

            CreateMap<EmployeePostDTO, Employee>();
            CreateMap<EmployeePutDTO, Employee>();
            CreateMap<Employee, EmployeeResponseDTO>();

            CreateMap<ProductPostDTO, Product>();
            CreateMap<ProductPutDTO, Product>();
            CreateMap<Product, ProductResponseDTO>();

            CreateMap<VariationPostDTO, Variation>();
            CreateMap<VariationPutDTO, Variation>();
            CreateMap<Variation, VariationResponseDTO>();

            CreateMap<MenuPostDTO, Menu>();
            CreateMap<MenuPutDTO, Menu>();
            CreateMap<MenuProductDTO, Product>();
            CreateMap<Menu, MenuResponseDTO>();

            CreateMap<PhoneDTO, Phone>().ReverseMap();
            CreateMap<AddressDTO, Address>().ReverseMap();
        }
    }
}
