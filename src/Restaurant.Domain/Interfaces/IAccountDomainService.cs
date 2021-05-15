using System;
using System.Threading.Tasks;
using Restaurant.Domain.Entities.Base;

namespace Restaurant.Domain.Interfaces
{
    public interface IAccountDomainService
    {
        Task<User> CreateAsync(User newUser);
        Task<User> UpdateAsync(User newUser);
        Task DeleteAsync(Guid id);
        Task<bool> Exists(Guid id);
        Task<string> GeneratePasswordResetTokenAsync(string userName);
        Task VerifyTokenAsync(string userName, string token);
        Task ResetPasswordAsync(string userName, string token, string password);
    }
}
