using Casha.Core.DbModels;
using Casha.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void DeleteUser(string userId)
        {
            User? user = this._context.Users.Find(userId);

            if (user is not null)
            {
                this._context.Users.Remove(user);
                this._context.SaveChanges();
            }
        }

        public User? GetUserByID(string userId)
        {
            return this._context.Users
                .Include(x => x.Posts)
                .Include(x => x.Recipes)
                .Include(x => x.Comments)
                .Include(x => x.UserProducts)
                .FirstOrDefault(x => x.Id.Equals(userId));
        }

        public List<User> GetUsers(Expression<Func<User, bool>> filter)
        {
            return this._context.Users
                .Include(x => x.Posts)
                .Include(x => x.Recipes)
                .Include(x => x.Comments)
                .Include(x => x.UserProducts)
                .Where(filter)
                .ToList();
        }

        public void UpdateUser(User user)
        {
            User? dbUser = this._context.Users.Find(user.Id);

            if (dbUser is not null)
            {
                dbUser.FirstName = user.FirstName;
                dbUser.LastName = user.LastName;
                dbUser.DisplayName = user.DisplayName;
                dbUser.Bio = user.Bio;
                dbUser.ProfilePictureUrl = user.ProfilePictureUrl;
                dbUser.IsCertified = dbUser.IsCertified;

                this._context.SaveChanges();
            }
        }
        public void AddUser(User user, String roleId)
        {
            this._context.Users.Add(user);
            IdentityUserRole<string> userRole = new Microsoft.AspNetCore.Identity.IdentityUserRole<string>();
            userRole.UserId = user.Id;
            userRole.RoleId = roleId;
            this._context.UserRoles.Add(userRole);

            this._context.SaveChanges();
        }
    }
}
