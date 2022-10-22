using CashaWeb.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CashaWeb.Controllers
{
    [Route("api/security/[controller]")]
    [ApiController]
    public class JwtController : Controller
    {
        

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUser user)
        {
            

            return Ok(stringToken);

        }
    }
}
