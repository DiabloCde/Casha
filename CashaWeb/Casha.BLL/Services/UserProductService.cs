using Casha.BLL.Interfaces;
using Casha.Core.DbModels;
using Casha.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Services
{
    public class UserProductService : IUserProductService
    {
        private readonly IUserProductRepository _userProductRepository;

        public UserProductService(IUserProductRepository userProductRepository)
        {
            _userProductRepository = userProductRepository;
        }

        public void AddProductToUserFridge(UserProduct userProduct)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductFromUserFridge(int userProductId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetUserProductsInFridge(string userId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetUserProductsInFridge(string userId, DateTimeOffset from, DateTimeOffset to, string search = "")
        {
            throw new NotImplementedException();
        }

        public List<Product> GetUserProductsInFridge(string userId, DateTimeOffset lastExpirationDay, string search = "")
        {
            throw new NotImplementedException();
        }

        public void UpdateProductInUserFridge(UserProduct userProduct)
        {
            throw new NotImplementedException();
        }
    }
}
