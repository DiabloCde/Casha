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
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationContext _context;

        public ProductTypeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void DeleteProductType(int productTypeId)
        {
            ProductType? productType = this._context.ProductTypes.Find(productTypeId);

            if (productType is not null)
            {
                this._context.ProductTypes.Remove(productType);
                this._context.SaveChanges();
            }
        }

        public ProductType? GetProductTypeByID(int productTypeId)
        {
            return this._context.ProductTypes
                .Include(x => x.Products)
                .FirstOrDefault(x => x.ProductTypeId == productTypeId);
        }

        public List<ProductType> GetProductTypes(Expression<Func<ProductType, bool>> filter)
        {
            return this._context.ProductTypes
                .Include(x => x.Products)
                .Where(filter)
                .ToList();
        }

        public void InsertProductType(ProductType productType)
        {
            this._context.ProductTypes.Add(productType);
            this._context.SaveChanges();
        }

        public void UpdateProductType(ProductType productType)
        {
            ProductType? dbProductType = this._context.ProductTypes.Find(productType.ProductTypeId);

            if (dbProductType is not null)
            {
                dbProductType.TypeName = productType.TypeName;

                this._context.SaveChanges();
            }
        }
    }
}
