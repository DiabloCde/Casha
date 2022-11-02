using Casha.BLL.Interfaces;
using CashaWeb.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            try
            {
                var token = await _accountService.LoginAsync(user.Login, user.Password);

                var cookieOptions = new CookieOptions()
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(1)
                };

                Response.Cookies.Append("loggedToken", token, cookieOptions);

                return Ok(token);
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (await _accountService.RegistrateAsync(model.Login, model.Password))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            if (await _accountService.ChangePasswordAsync(
                changePasswordViewModel.Username,
                changePasswordViewModel.OldPassword,
                changePasswordViewModel.NewPassword))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
