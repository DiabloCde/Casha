using Casha.BLL.Interfaces;
using Casha.DAL.Interfaces;

namespace Casha.BLL.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public string Login(string username, string password)
        {
            // TODO: decifer password before comparison
            var logged = _userRepository.GetUsers(u => u.UserName == username && u.PasswordHash == password).First();

            if (logged == null)
            {
                throw new InvalidOperationException("User not found");
            }

            return _tokenService.GenerateToken(logged);
        }
    }
}
