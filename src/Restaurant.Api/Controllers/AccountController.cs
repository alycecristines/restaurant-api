using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.DTOs.Authentication;
using Restaurant.Api.Wrappers;
using Restaurant.Core.Services.Base;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IAccountService _accountService;

        public AccountController(IJwtTokenService jwtTokenService,
            IAccountService accountService)
        {
            _jwtTokenService = jwtTokenService;
            _accountService = accountService;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignInDTO dto)
        {
            var token = await _jwtTokenService.GenerateAsync(dto.UserName, dto.Password);
            var response = new Response(token);

            return Ok(response);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO dto)
        {
            var token = await _accountService.GeneratePasswordResetTokenAsync(dto.UserName);

            // TODO: Send token by email.
            return Ok(token);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO dto)
        {
            await _accountService.ResetPasswordAsync(dto.UserName, dto.Token, dto.Password);

            return Ok();
        }

        [HttpPost("verify-token")]
        public async Task<IActionResult> VerifyToken(VerifyTokenDTO dto)
        {
            await _accountService.VerifyTokenAsync(dto.UserName, dto.Token);

            return Ok();
        }
    }
}
