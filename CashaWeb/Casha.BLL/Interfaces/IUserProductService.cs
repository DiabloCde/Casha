
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casha.Core.DbModels;
using Casha.Core.Enums;

namespace Casha.BLL.Interfaces
{
    public interface IUserProductService
    {
        List<UserProduct> GetAllUserProducts();

        UserProduct? GetUserProductByID(int userProductId);

        void AddUserProduct(UserProduct userProduct);

        void DeleteUserProduct(int userProductId);

        void UpdateUserProduct(UserProduct userProduct);

        public List<UserProduct> GetUserProductsByUserId(string userId);
    }
}
