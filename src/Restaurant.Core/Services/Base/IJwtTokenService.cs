using System.Threading.Tasks;

namespace Restaurant.Core.Services.Base
{
    public interface IJwtTokenService
    {
        Task<object> GenerateAsync(string userName, string password);
    }
}
