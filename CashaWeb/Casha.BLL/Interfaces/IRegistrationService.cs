using Casha.Core.DbModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Interfaces
{
    public interface IRegistrationService
    {
        Task<bool> registrateAsync(String login, String password);

        Task<bool> isThereSuchLoginAsync(String login);
        
    }
}
