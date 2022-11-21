using Casha.BLL.Interfaces;
using Casha.BLL.Services;
using Casha.Core.DbModels;
using CashaWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserDetails(string userId)
        {
            try
            {
                User? user = this._userService.GetUserDetails(userId);

                if (user is null)
                {
                    return NotFound();
                }

                UserViewModel userViewModel = new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DisplayName = user.DisplayName,
                    Bio = user.Bio,
                    ProfilePictureUrl = user.ProfilePictureUrl,
                    IsCertified = user.IsCertified
                };

                return Ok(userViewModel);
            }
            catch (ArgumentNullException ex)
            {
                this._logger.LogError(ex.Message);

                return ValidationProblem(ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(
            [FromRoute]
            string userId,
            [FromBody]
            UserViewModel userViewModel)
        {
            try
            {
                User user = new User
                {
                    Id = userId,
                    Email = userViewModel.Email,
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                    DisplayName = userViewModel.DisplayName,
                    Bio = userViewModel.Bio,
                    ProfilePictureUrl = userViewModel.ProfilePictureUrl,
                    IsCertified = userViewModel.IsCertified,
                };

                this._userService.UpdateUser(user);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{userId}")]
        public IActionResult RemoveUser(string userId)
        {
            try
            {
                this._userService.DeleteUser(userId);

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                this._logger.LogError(ex.Message);

                return ValidationProblem(ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUsers(
            [FromQuery]
            bool isAllUsers = true,
            [FromQuery]
            bool isCertifiedUsers = false, 
            [FromQuery]            
            string search = "")
        {
            try
            {
                List<User> users = this._userService.GetUsers(isAllUsers, isCertifiedUsers, search);

                List<UserViewModel> userViewModels = users.Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    DisplayName = u.DisplayName,
                    Bio = u.Bio,
                    ProfilePictureUrl = u.ProfilePictureUrl,
                    IsCertified = u.IsCertified,
                }).ToList();

                return Ok(userViewModels);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("All")]
        public IActionResult GetAllUsers()
        {
            try
            {
                List<User> users = this._userService.GetAllUsers();

                List<UserViewModel> userViewModels = users.Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    DisplayName = u.DisplayName,
                    Bio = u.Bio,
                    ProfilePictureUrl = u.ProfilePictureUrl,
                    IsCertified = u.IsCertified,
                }).ToList();

                return Ok(userViewModels);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
