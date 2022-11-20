using Casha.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.DAL.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProducts(Expression<Func<Product, bool>> filter);

        Product? GetProductByID(int productId);

        void InsertProduct(Product product);

        void DeleteProduct(int productId);

        void UpdateProduct(Product product);     
    }
}
