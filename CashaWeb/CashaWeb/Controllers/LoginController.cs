using Casha.BLL.Interfaces;
using Casha.Core.DbModels;
using CashaWeb.ApiModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CashaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginController(ILoginService loginServcie, SignInManager<User> signInManager, UserManager<User> userManager, ITokenService tokenService)
        {
            _loginService = loginServcie;
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            try
            {
                var token = await _loginService.Login(user.Login, user.Password);

                var cookieOptions = new CookieOptions()
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(1)
                };

                Response.Cookies.Append("loggedToken", token, cookieOptions);

                return Ok();
            }
            catch(InvalidOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
