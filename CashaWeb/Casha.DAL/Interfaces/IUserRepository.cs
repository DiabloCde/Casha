using Casha.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.DAL.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers(Expression<Func<User, bool>> filter);

        List<User> GetAllUsers();

        User? GetUserByID(string userId);

        void DeleteUser(string userId);

        void UpdateUser(User user);
    }
}
