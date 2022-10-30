using Casha.Core.DbModels;
using CashaWeb.ApiModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashaWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase

    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        
        
        public RegisterController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = model.Login };
                if (await userManager.Users.AnyAsync(x => x.UserName == model.Login))
                    return ValidationProblem();
                IdentityResult result;
                try
                {
                    result = await userManager.CreateAsync(user, model.Password);
                }
                catch
                {
                    Console.WriteLine("Validation exception");
                    return ValidationProblem();
                }

                if (result.Succeeded)
                {
                    var defaultRole = await roleManager.FindByNameAsync("default");
                    if (defaultRole != null)
                    {
                        var roleResult = await userManager.AddToRoleAsync(user, defaultRole.Name);
                    }
                    else
                    {
                        await roleManager.CreateAsync(new IdentityRole("default"));
                    }
                }
            }
            return Ok();
        }
    }

}
    
    

