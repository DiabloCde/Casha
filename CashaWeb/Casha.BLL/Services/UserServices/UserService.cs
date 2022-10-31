using Casha.BLL.Interfaces;
using Casha.Core.DbModels;
using Casha.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public void DeleteUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("The userId is not valid.");
            }

            try
            {
                _userRepository.DeleteUser(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public User? GetUserDetails(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("The userId is not valid.");
            }

            try
            {
                User? user = _userRepository.GetUserByID(userId);

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

            }

            return null;
        }

        public List<User> GetUsers(bool isAllUsers = true, bool isCertifiedUsers = false, string search = "")
        {
            try
            {
                List<User> users = _userRepository.GetUsers(u =>
                    (u.FirstName.Contains(search)
                        || u.LastName.Contains(search))
                    && (u.IsCertified == isCertifiedUsers
                        || isAllUsers));

                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return new List<User>();
        }

        public void UpdateUser(User user)
        {
            try
            {
                _userRepository.UpdateUser(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
