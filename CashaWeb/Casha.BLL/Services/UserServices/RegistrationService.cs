using Casha.Core.DbModels;
using Casha.DAL.Interfaces;
using Casha.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Services.UserServices
{
    internal class RegistrationService
    {
        private readonly IUserRepository _userRepository;
        public RegistrationService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public bool registrate(String login, String password)
        {
            //if (isLoginUnique(login))
            //{
            //    String hashedPassword = SecurePasswordHasher.Hash(password);
            //    User user = new User(login, hashedPassword);
            //    _userRepository.AddUser(user, "0");
            //    return true;
            //}
            return false;
        }
        private bool isLoginUnique(String login)
        {
            List<User> users = _userRepository.GetUsers(x => x.UserName==login);
            return users.Count == 0;
        }
         
    }
}
