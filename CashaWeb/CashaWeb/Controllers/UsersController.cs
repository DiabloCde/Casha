﻿using Casha.DAL.Interfaces;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(Expression<Func<User, bool>> filter)
        {
            var users = _userRepository.GetUsers(filter);
            if(users.Any())
            {
                return Ok(users);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            _userRepository.DeleteUser(id.ToString());
            return Ok();
        }
    }
}
