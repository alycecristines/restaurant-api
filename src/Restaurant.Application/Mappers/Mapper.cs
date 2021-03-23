using AutoMapper;
using Restaurant.Application.DTOs.Common;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.DTOs.Response;
using Restaurant.Core.Entities;
using Restaurant.Core.ValueObjects;

namespace Restaurant.Application.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CompanyPostDTO, Company>();
            CreateMap<DepartmentPostDTO, Department>();
            CreateMap<EmployeePostDTO, Employee>();

            CreateMap<CompanyPutDTO, Company>();
            CreateMap<DepartmentPutDTO, Department>();

            CreateMap<Company, CompanyResponseDTO>();
            CreateMap<Department, DepartmentResponseDTO>();
            CreateMap<Employee, EmployeeResponseDTO>();

            CreateMap<PhoneDTO, Phone>().ReverseMap();
            CreateMap<AddressDTO, Address>().ReverseMap();
        }
    }
}
