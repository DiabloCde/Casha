using Casha.BLL.Interfaces;
using Casha.BLL.Services.UserServices;
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
    public class RegistrationController : ControllerBase

    {
        private IRegistrationService registrationService;
        
        
        public RegistrationController(IRegistrationService registrationService)
        {
            this.registrationService = registrationService; 
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (await registrationService.registrateAsync(model.Login, model.Password))
                    return Ok();
                else
                    return ValidationProblem();
            }
            return Ok();
        }
    }

}
    
    

