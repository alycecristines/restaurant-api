using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Entities.Base;
using Restaurant.Domain.ValueObjects;
using Restaurant.Infrastructure.Identity.Models;
using Restaurant.Infrastructure.Identity.Options;

namespace Restaurant.Infrastructure.Identity.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AdministratorOptions, ApplicationUser>();
            CreateMap<Employee, ApplicationUser>();
            CreateMap<User, ApplicationUser>().ReverseMap();

            CreateMap<User, UserToken>().ForMember(userToken => userToken.User, config => config.MapFrom(user => user));
            CreateMap<string, UserToken>().ForMember(userToken => userToken.Token, config => config.MapFrom(token => token));
        }
    }
}
