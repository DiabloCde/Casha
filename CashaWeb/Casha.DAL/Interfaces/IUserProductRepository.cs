using Casha.Core.DbModels;
using System.Linq.Expressions;

namespace Casha.DAL.Interfaces
{
    public interface IUserProductRepository
    {
        List<Product> GetUserProducts(string userId);

        List<Product> GetUserProducts(string userId, Expression<Func<Product, bool>> expression);

        void AddUserProduct(UserProduct userProduct);

        void UpdateUserProduct(UserProduct userProduct);

        void DeleteUserProduct(int userProductId);
    }
}
