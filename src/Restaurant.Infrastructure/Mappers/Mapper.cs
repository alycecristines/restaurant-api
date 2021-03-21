using AutoMapper;
using Restaurant.Core.DTOs.Common;
using Restaurant.Core.DTOs.Request;
using Restaurant.Core.DTOs.Response;
using Restaurant.Core.Entities;
using Restaurant.Core.ValueObjects;

namespace Restaurant.Infrastructure.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CompanyPostDTO, Company>();
            CreateMap<CompanyPutDTO, Company>();
            CreateMap<Company, CompanyResponseDTO>();
            CreateMap<PhoneDTO, Phone>();
            CreateMap<AddressDTO, Address>();
        }
    }
}
