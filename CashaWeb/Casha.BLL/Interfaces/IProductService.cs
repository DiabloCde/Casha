using Casha.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Product? GetProductByID(int productId);

        void AddProduct(Product product);

        void DeleteProduct(int productId);

        void UpdateProduct(Product product);
    }
}
