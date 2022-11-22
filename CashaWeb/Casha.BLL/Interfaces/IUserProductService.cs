using Casha.Core.DbModels;

namespace Casha.BLL.Interfaces
{
    public interface IUserProductService
    {
        void AddProductToUserFridge(UserProduct userProduct);

        void DeleteProductFromUserFridge(int userProductId);

        void UpdateProductInUserFridge(UserProduct userProduct);

        List<Product> GetUserProductsInFridge(string userId);

        List<Product> GetUserProductsInFridge(string userId, DateTimeOffset from, DateTimeOffset to, string search = "");

        List<Product> GetUserProductsInFridge(string userId, DateTimeOffset lastExpirationDay, string search = "");
    }
}
