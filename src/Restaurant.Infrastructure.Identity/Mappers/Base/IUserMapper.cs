using Restaurant.Core.Entities;
using Restaurant.Infrastructure.Identity.Models;
using Restaurant.Infrastructure.Identity.Options;

namespace Restaurant.Infrastructure.Identity.Mappers.Base
{
    public interface IUserMapper
    {
        ApplicationUser Map(Employee employee);
        ApplicationUser Map(AdministratorOptions options);
        void Map(Employee source, ApplicationUser destination);
        void Map(AdministratorOptions source, ApplicationUser destination);
    }
}
