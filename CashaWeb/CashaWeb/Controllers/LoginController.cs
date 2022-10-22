using Casha.BLL.Interfaces;
using CashaWeb.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace CashaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginServcie;

        public LoginController(ILoginService loginServcie)
        {
            _loginServcie = loginServcie;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser user)
        {
            try
            {
                return Ok(_loginServcie.Login(user.Login, user.Password));
            }
            catch(InvalidOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
