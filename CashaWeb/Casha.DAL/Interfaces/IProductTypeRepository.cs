using Casha.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.DAL.Interfaces
{
    public interface IProductTypeRepository
    {
        List<ProductType> GetProductTypes(Expression<Func<ProductType, bool>> filter);

        ProductType? GetProductTypeByID(int productTypeId);

        void InsertProductType(ProductType productType);

        void DeleteProductType(int productTypeId);

        void UpdateProductType(ProductType productType);
    }
}
