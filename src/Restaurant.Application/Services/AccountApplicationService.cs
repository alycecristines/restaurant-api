using System.Threading.Tasks;
using Restaurant.Application.Models.Authentication;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Interfaces;
using Restaurant.Application.Models;
using AutoMapper;

namespace Restaurant.Application.Services
{
    public class AccountApplicationService : IAccountApplicationService
    {
        private readonly IAccountDomainService _accountService;
        private readonly IJwtTokenDomainService _jwtTokenService;
        private readonly IMapper _mapper;

        public AccountApplicationService(IAccountDomainService accountService,
            IJwtTokenDomainService jwtTokenService, IMapper mapper)
        {
            _accountService = accountService;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
        }

        public async Task<UserTokenResponseModel> SignIn(SignInModel model)
        {
            var userToken = await _jwtTokenService.GenerateAsync(model.UserName, model.Password);
            return _mapper.Map<UserTokenResponseModel>(userToken);
        }

        public async Task<string> ForgotPassword(ForgotPasswordModel model)
        {
            // TODO: Send token by email.
            return await _accountService.GeneratePasswordResetTokenAsync(model.UserName);
        }

        public async Task ResetPassword(ResetPasswordModel model)
        {
            await _accountService.ResetPasswordAsync(model.UserName, model.Token, model.Password);
        }

        public async Task VerifyToken(VerifyTokenModel model)
        {
            await _accountService.VerifyTokenAsync(model.UserName, model.Token);
        }
    }
}
