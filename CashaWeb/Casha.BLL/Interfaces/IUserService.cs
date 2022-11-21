using Casha.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Interfaces
{
    public interface IUserService
    {
        void UpdateUser(User user);

        void DeleteUser(string userId);

        User? GetUserDetails(string userId);

        List<User> GetUsers(bool isAllUsers = true, bool isCertifiedUsers = false, string search = "");

        List<User> GetAllUsers();
    }
}
