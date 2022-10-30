using Casha.BLL.Interfaces;
using Casha.Core.DbModels;
using Casha.DAL.Interfaces;
using Casha.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Services.UserServices
{
    public class RegistrationService : IRegistrationService
    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private ILogger<RegistrationService> logger;

        public RegistrationService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ILogger<RegistrationService> logger)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.logger = logger;
        }
        public async Task<bool> registrateAsync(String login, String password)
        {
            User user = new User { UserName = login };
            if (await isThereSuchLoginAsync(login))
            {
                logger.LogError("Validation exception user with such login already exists");
                return false;
            }
                
            IdentityResult result;
            try
            {
                result = await userManager.CreateAsync(user, password);
            }
            catch
            {
                logger.LogError("Validation exception problems when creating a user");
                return false;
            }

            if (result.Succeeded)
            {
                var defaultRole = await roleManager.FindByNameAsync("default");
                if (defaultRole != null)
                {
                    var roleResult = await userManager.AddToRoleAsync(user, defaultRole.Name);
                }
            }
            return true;
        }
        public async Task<bool> isThereSuchLoginAsync(String login)
        {
            return await userManager.Users.AnyAsync(x => x.UserName == login);
        }
         
    }
}
