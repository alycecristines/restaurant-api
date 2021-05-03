using System.Threading.Tasks;
using Restaurant.Core.Entities;
using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Services.Base
{
    public interface IAccountService
    {
        Task CreateAsync(Employee newEmployee);
        Task UpdateAsync(Employee newEmployee);
        Task DeleteAsync(Entity entity);
        Task<string> GeneratePasswordResetTokenAsync(string userName);
        Task VerifyTokenAsync(string userName, string token);
        Task ResetPasswordAsync(string userName, string token, string password);
    }
}
