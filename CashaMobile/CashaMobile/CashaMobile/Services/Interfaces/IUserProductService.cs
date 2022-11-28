using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CashaMobile.Models;

namespace CashaMobile.Services.Interfaces
{
    public interface IUserProductService
    {
        Task<UserProduct> GetUserProductByID(int userProductId);

        Task AddUserProduct(UserProduct userProduct);

        Task DeleteUserProduct(int userProductId);

        Task UpdateUserProduct(UserProduct userProduct);

        Task<List<UserProduct>> GetUserProductsByUserId(string userId);
    }
}
