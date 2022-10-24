using Casha.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Casha.DAL;
using Casha.Core.DbModels;
using System.Linq.Expressions;

namespace CashaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser(int id)
        {
            var user = _userRepository.GetUserByID(id.ToString());

            if(user != null)
            {
                return Ok(user);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(User user)
        {
            _userRepository.UpdateUser(user);
            return Ok();
        }
    }
}
