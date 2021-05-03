using Restaurant.Core.Entities;
using Restaurant.Infrastructure.Identity.Mappers.Base;
using Restaurant.Infrastructure.Identity.Models;
using Restaurant.Infrastructure.Identity.Options;

namespace Restaurant.Infrastructure.Identity.Mappers
{
    public class UserMapper : IUserMapper
    {
        public ApplicationUser Map(Employee employee)
        {
            return new ApplicationUser
            {
                Id = employee.Id.ToString(),
                UserName = employee.Email,
                Email = employee.Email,
                Name = employee.Name
            };
        }

        public ApplicationUser Map(AdministratorOptions options)
        {
            return new ApplicationUser
            {
                UserName = options.UserName,
                Email = options.Email,
                Name = options.Name
            };
        }

        public void Map(Employee source, ApplicationUser destination)
        {
            destination.UserName = source.Email;
            destination.Email = source.Email;
            destination.Name = source.Name;
        }

        public void Map(AdministratorOptions source, ApplicationUser destination)
        {
            destination.Name = source.Name;
            destination.Email = source.UserName;
        }
    }
}
