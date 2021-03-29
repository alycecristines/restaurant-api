using AutoMapper;
using Restaurant.Api.DTOs.Common;
using Restaurant.Api.DTOs.Company;
using Restaurant.Api.DTOs.Department;
using Restaurant.Api.DTOs.Employee;
using Restaurant.Api.DTOs.Product;
using Restaurant.Core.Entities;
using Restaurant.Core.ValueObjects;

namespace Restaurant.Api.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
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

            CreateMap<PhoneDTO, Phone>().ReverseMap();
            CreateMap<AddressDTO, Address>().ReverseMap();
        }
    }
}
