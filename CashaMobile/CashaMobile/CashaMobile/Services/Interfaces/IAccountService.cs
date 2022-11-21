using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashaMobile.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string login, string password);
    }
}
