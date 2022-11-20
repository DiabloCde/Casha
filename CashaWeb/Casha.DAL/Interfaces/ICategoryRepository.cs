using Casha.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories(Expression<Func<Category, bool>> filter);

        Category? GetCategoryByID(int categoryId);

        void InsertCategory(Category category);

        void DeleteCategory(int categoryId);

        void UpdateCategory(Category category);
    }
}
