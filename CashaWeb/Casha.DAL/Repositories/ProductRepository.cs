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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void DeleteProduct(int productId)
        {
            Product? product = this._context.Products.Find(productId);

            if (product is not null)
            {
                this._context.Products.Remove(product);
                this._context.SaveChanges();
            }
        }

        public Product? GetProductByID(int productId)
        {
            return this._context.Products
                .Include(x => x.UserProducts)
                .Include(x => x.UserProducts)
                .FirstOrDefault(x => x.ProductId == productId);
        }

        public List<Product> GetProducts(Expression<Func<Product, bool>> filter)
        {
            return this._context.Products
                .Include(x => x.UserProducts)
                .Include(x => x.UserProducts)
                .Where(filter)
                .ToList();
        }

        public void InsertProduct(Product product)
        {
            this._context.Products.Add(product);
            this._context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            Product? dbProduct = this._context.Products.Find(product.ProductId);

            if (dbProduct is not null)
            {
                dbProduct.Name = product.Name;

                this._context.SaveChanges();
            }
        }
    }
}
