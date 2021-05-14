using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Models.Authentication;
using Restaurant.Api.Wrappers;
using Restaurant.Application.Interfaces;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountApplicationService _accountService;

        public AccountController(IAccountApplicationService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var userToken = await _accountService.SignIn(model);
            var response = new Response(userToken);
            return Ok(response);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            await _accountService.ForgotPassword(model);
            var response = new Response();
            return Ok(response);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            await _accountService.ResetPassword(model);
            var response = new Response();
            return Ok(response);
        }

        [HttpPost("verify-token")]
        public async Task<IActionResult> VerifyToken(VerifyTokenModel model)
        {
            await _accountService.VerifyToken(model);
            var response = new Response();
            return Ok(response);
        }
    }
}
