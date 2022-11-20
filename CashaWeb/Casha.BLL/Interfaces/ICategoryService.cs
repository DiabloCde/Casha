using Casha.Core.DbModels;
using Casha.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();

        List<Category> GetCategoriesByType(CategoryType categoryType);

        Category? GetCategoryByID(int categoryId);

        void AddCategory(Category category);

        void DeleteCategory(int categoryId);

        void UpdateCategory(Category category);
    }
}
