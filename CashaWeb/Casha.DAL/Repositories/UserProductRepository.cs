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

        public void AddUserProduct(UserProduct userProduct)
        {
            _context.UserProducts.Add(userProduct);
            _context.SaveChanges();
        }

        public void DeleteUserProduct(int userProductId)
        {
            UserProduct? userProduct = this._context.UserProducts.FirstOrDefault(u =>
                u.UserProductId == userProductId);

            if (userProduct is not null)
            {
                this._context.UserProducts.Remove(userProduct);
                this._context.SaveChanges();
            }
        }

        public List<Product> GetUserProducts(string userId)
        {
            List<Product> products = new List<Product>();

            User? user = _context.Users
                .Include(u => u.UserProducts)
                    .ThenInclude(p => p.Product)
                .FirstOrDefault(u => u.Id.Equals(userId));

            if (user is not null)
            {
                products = user.UserProducts.Select(p => p.Product).ToList();
            }

            return products;
        }

        public List<Product> GetUserProducts(string userId, Expression<Func<Product, bool>> expression)
        {
            List<Product> products = new List<Product>();

            User? user = _context.Users
                .Include(u => u.UserProducts)
                    .ThenInclude(p => p.Product)
                .FirstOrDefault(u => u.Id.Equals(userId));

            if (user is not null)
            {
                products = user.UserProducts
                    .AsQueryable()
                    .Select(p => p.Product)
                    .Where(expression)
                    .ToList();
            }

            return products;
        }

        public void UpdateUserProduct(UserProduct userProduct)
        {
            UserProduct? dbUserProduct = _context.UserProducts.FirstOrDefault(u => 
                u.UserId.Equals(userProduct.UserId)
                && u.ProductId == u.ProductId
                && u.UserProductId == u.UserProductId);

            if (dbUserProduct is not null)
            {
                dbUserProduct.ExpirationDate = userProduct.ExpirationDate;
                dbUserProduct.Quantity = userProduct.Quantity;

                this._context.SaveChanges();
            }
        }
    }
}
