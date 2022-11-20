using Casha.BLL.Interfaces;
using Casha.Core.DbModels;
using Casha.Core.Enums;
using Casha.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public void AddCategory(Category category)
        {
            try
            {
                this._categoryRepository.InsertCategory(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void DeleteCategory(int categoryId)
        {
            if (categoryId <= 0)
            {
                throw new ArgumentNullException("The categoryId is not valid.");
            }

            try
            {
                this._categoryRepository.DeleteCategory(categoryId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public List<Category> GetAllCategories()
        {
            try
            {
                return this._categoryRepository.GetCategories(c => c.CategoryId > 0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new List<Category>();
            }
        }

        public List<Category> GetCategoriesByType(CategoryType categoryType)
        {
            try
            {
                return this._categoryRepository.GetCategories(c => c.CategoryType.Equals(categoryType);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new List<Category>();
            }
        }

        public Category? GetCategoryByID(int categoryId)
        {
            if (categoryId <= 0)
            {
                throw new ArgumentNullException("The categoryId is not valid.");
            }

            try
            {
                return this._categoryRepository.GetCategoryByID(categoryId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return null;
            }
        }

        public void UpdateCategory(Category category)
        {
            if (category.CategoryId <= 0)
            {
                throw new ArgumentNullException("The categoryId is not valid.");
            }

            try
            {
                this._categoryRepository.UpdateCategory(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
