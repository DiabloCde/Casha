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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void InsertCategory(Category category)
        {
            this._context.Categories.Add(category);
            this._context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            Category? category = this._context.Categories.Find(categoryId);

            if (category is not null)
            {
                this._context.Categories.Remove(category);
                this._context.SaveChanges();
            }
        }

        public List<Category> GetCategories(Expression<Func<Category, bool>> filter)
        {
            return this._context.Categories
                .Include(c => c.RecipeCategories)
                .Where(filter)
                .ToList();
        }

        public Category? GetCategoryByID(int categoryId)
        {
            return this._context.Categories
                .Include(c => c.RecipeCategories)
                .FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public void UpdateCategory(Category category)
        {
            Category? dbCategory = this._context.Categories.Find(category.CategoryId);

            if(dbCategory is not null)
            {
                dbCategory.CategoryName = category.CategoryName;
                dbCategory.CategoryType = category.CategoryType;

                this._context.SaveChanges();
            }
        }
    }
}
