using Casha.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.DAL.Interfaces
{
    public interface IUserProductRepository
    {
        List<UserProduct> GetUserProducts(Expression<Func<UserProduct, bool>> filter);

        UserProduct? GetUserProductByID(int userProductId);

        void InsertUserProduct(UserProduct userProduct);

        void DeleteUserProduct(int userProductId);

        void UpdateUserProduct(UserProduct userProduct);
    }
}
