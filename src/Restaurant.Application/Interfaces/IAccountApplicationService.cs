using System.Threading.Tasks;
using Restaurant.Application.Models;
using Restaurant.Application.Models.Authentication;

namespace Restaurant.Application.Interfaces
{
    public interface IAccountApplicationService
    {
        Task<UserTokenResponseModel> SignIn(SignInModel model);
        Task<string> ForgotPassword(ForgotPasswordModel model);
        Task ResetPassword(ResetPasswordModel model);
        Task VerifyToken(VerifyTokenModel model);
    }
}
