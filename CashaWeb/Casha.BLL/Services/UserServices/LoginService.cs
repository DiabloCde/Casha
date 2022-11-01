using Casha.BLL.Interfaces;
using Casha.Core.DbModels;
using Casha.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Casha.BLL.Services.UserServices
{
    public class LoginService : ILoginService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userReposity;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginService(ITokenService tokenService, IUserRepository userReposity, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _tokenService = tokenService;
            _userReposity = userReposity;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> Login(string username, string password)
        {
            var logged = _userReposity.GetUsers(x => x.UserName.Equals(username)).FirstOrDefault();

            if (logged == null)
            {
                throw new InvalidOperationException("User not found");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(logged, password, false);

            var roles = await _userManager.GetRolesAsync(logged);

            if (result.Succeeded)
            {
                return _tokenService.GenerateToken(logged, roles);
            }

            throw new InvalidOperationException("Incorrect password");
        }
    }
}
