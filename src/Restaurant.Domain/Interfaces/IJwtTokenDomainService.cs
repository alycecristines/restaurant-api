using System.Threading.Tasks;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Domain.Interfaces
{
    public interface IJwtTokenDomainService
    {
        Task<UserToken> GenerateAsync(string userName, string password);
    }
}
