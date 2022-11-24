using Casha.Core.DbModels;
using Casha.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.DAL.Repositories
{
    public class UserProductRepository : IUserProductRepository
    {
        private readonly ApplicationContext _context;

        public UserProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void DeleteUserProduct(int userProductId)
        {
            UserProduct? userProduct = this._context.UserProducts.Find(userProductId);

            if (userProduct is not null)
            {
                this._context.UserProducts.Remove(userProduct);
                this._context.SaveChanges();
            }
        }

        public UserProduct? GetUserProductByID(int userProductId)
        {
            return _context.UserProducts
                .Include(c => c.User)
                .Include(c => c.Product)
                .FirstOrDefault(c => c.UserProductId == userProductId);
        }

        public List<UserProduct> GetUserProducts(Expression<Func<UserProduct, bool>> filter)
        {
            return this._context.UserProducts
                .Include(c => c.User)
                .Include(c => c.Product)
                .Where(filter)
                .ToList();
        }

        public void InsertUserProduct(UserProduct userProduct)
        {
            this._context.UserProducts.Add(userProduct);
            this._context.SaveChanges();
        }

        public void UpdateUserProduct(UserProduct userProduct)
        {

            UserProduct? dbUserProduct = this._context.UserProducts.Find(userProduct.UserProductId);

            if (dbUserProduct is not null)
            {
                dbUserProduct.Quantity = userProduct.Quantity;
                dbUserProduct.ExpirationDate = userProduct.ExpirationDate;

                this._context.SaveChanges();
            }
        }
    }
}
