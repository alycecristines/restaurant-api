using AutoMapper;
using Restaurant.Application.DTOs.Common;
using Restaurant.Application.DTOs.Company;
using Restaurant.Application.DTOs.Department;
using Restaurant.Application.DTOs.Employee;
using Restaurant.Application.DTOs.Product;
using Restaurant.Core.Entities;
using Restaurant.Core.ValueObjects;

namespace Restaurant.Application.Mappers
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
            CreateMap<Product, ProductResponseDTO>();

            CreateMap<PhoneDTO, Phone>().ReverseMap();
            CreateMap<AddressDTO, Address>().ReverseMap();
        }
    }
}
