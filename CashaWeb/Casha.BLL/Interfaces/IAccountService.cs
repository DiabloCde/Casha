using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<string> LoginAsync(string username, string password);

        Task<bool> RegistrateAsync(string login, string password);

        Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword);
    }
}
