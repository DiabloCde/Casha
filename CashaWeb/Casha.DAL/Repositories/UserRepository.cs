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

        public List<User> GetAllUsers()
        {
            return this._context.Users
                .Include(x => x.Posts)
                .Include(x => x.Recipes)
                .Include(x => x.Comments)
                .Include(x => x.UserProducts)
                .ToList();
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

        public List<User> GetUsersAdminFilter(string userName, string firstName, string secondName)
        {
            List<User> users = _context.Users
                .Include(x => x.Posts)
                .Include(x => x.Recipes)
                .Include(x => x.Comments)
                .Include(x => x.UserProducts)
                .ToList();

            if (userName.Length > 0)
            {
                users = users.Where(u => u.DisplayName != null && u.DisplayName.Contains(userName)).ToList();
            }
            if(firstName.Length > 0)
            {
                users = users.Where(u=>u.FirstName != null && u.FirstName.Contains(firstName)).ToList();
            }
            if (secondName.Length > 0)
            {
                users = users.Where(u => u.LastName != null && u.LastName.Contains(secondName)).ToList();
            }

            return users;
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
    }
}
