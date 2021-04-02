using AutoMapper;
using Restaurant.Application.DTOs.Common;
using Restaurant.Application.DTOs.Company;
using Restaurant.Application.DTOs.Department;
using Restaurant.Application.DTOs.Employee;
using Restaurant.Application.DTOs.Menu;
using Restaurant.Application.DTOs.Product;
using Restaurant.Application.DTOs.Variation;
using Restaurant.Core.Entities;
using Restaurant.Core.ValueObjects;

namespace Restaurant.Infrastructure.Mappings
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
