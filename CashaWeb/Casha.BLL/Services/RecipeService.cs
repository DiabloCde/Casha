using Casha.BLL.Interfaces;
using Casha.Core.DbModels;
using Casha.Core.Dtos;
using Casha.DAL.Interfaces;
using Casha.DAL.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        private readonly IUserProductRepository _userProductRepository;

        private readonly ILogger<RecipeService> _logger;

        public RecipeService(
            IRecipeRepository recipeRepository,
            IUserProductRepository userProductRepository,
            ILogger<RecipeService> logger)
        {
            _recipeRepository = recipeRepository;
            _userProductRepository = userProductRepository;
            _logger = logger;
        }

        public List<Recipe> GetRecipes(RecipeFilterDto recipeFilter)
        {
            List<Recipe> recipes = new List<Recipe>();
            try
            {
                recipes = _recipeRepository.GetRecipes(r =>
                    r.Name.ToLower().Contains(recipeFilter.Name.ToLower())
                    && r.UserId.Contains(recipeFilter.UserId)
                    && (recipeFilter.Difficulty == null
                        || r.Difficulty == recipeFilter.Difficulty)
                    && r.RecipeProducts.Any(p => recipeFilter.RecipeProducts.Contains(p.ProductId)
                    && r.RecipeCategories.Any(c => recipeFilter.RecipeCategories.Contains(c.CategoryId))));

                return recipes;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return recipes;
        }

        public Recipe? GetRecipeByID(int recipeId)
        {
            if (recipeId < 0)
            {
                throw new ArgumentNullException("Recipe id must be greater than 0.");
            }

            try
            {
                Recipe? recipe = _recipeRepository.GetRecipeByID(recipeId);

                return recipe;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return null;
        }

        public void AddRecipe(Recipe recipe)
        {
            try
            {
                _recipeRepository.InsertRecipe(recipe);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public void UpdateRecipe(Recipe recipe)
        {
            if (recipe.RecipeId < 0)
            {
                throw new ArgumentNullException("Recipe id must be greater than 0.");
            }

            try
            {
                _recipeRepository.UpdateRecipe(recipe);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public void DeleteRecipe(int recipeId)
        {
            if (recipeId <= 0)
            {
                throw new ArgumentNullException("The recipeId is not valid.");
            }

            try
            {
                _recipeRepository.DeleteRecipe(recipeId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void AddProductToRecipe(RecipeProduct recipeProduct)
        {
            if (recipeProduct.RecipeId <= 0)
            {
                throw new ArgumentNullException("The recipeId is not valid.");
            }

            if (recipeProduct.ProductId <= 0)
            {
                throw new ArgumentNullException("The productId is not valid.");
            }

            try
            {
                _recipeRepository.AddProductToRecipe(recipeProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void RemoveProductFromRecipe(int productId, int recipeId)
        {
            if (recipeId <= 0)
            {
                throw new ArgumentNullException("The recipeId is not valid.");
            }

            if (productId <= 0)
            {
                throw new ArgumentNullException("The productId is not valid.");
            }

            try
            {
                _recipeRepository.RemoveProductFromRecipe(productId, recipeId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void UpdateProductInRecipe(RecipeProduct recipeProduct)
        {
            if (recipeProduct.RecipeId <= 0)
            {
                throw new ArgumentNullException("The recipeId is not valid.");
            }

            if (recipeProduct.ProductId <= 0)
            {
                throw new ArgumentNullException("The productId is not valid.");
            }

            try
            {
                _recipeRepository.UpdateProductInRecipe(recipeProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void AddCategoryToRecipe(RecipeCategory recipeCategory)
        {
            if (recipeCategory.RecipeId <= 0)
            {
                throw new ArgumentNullException("The recipeId is not valid.");
            }

            if (recipeCategory.CategoryId <= 0)
            {
                throw new ArgumentNullException("The categoryId is not valid.");
            }

            try
            {
                _recipeRepository.AddCategoryToRecipe(recipeCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void RemoveCategoryFromRecipe(int categoryId, int recipeId)
        {
            if (recipeId <= 0)
            {
                throw new ArgumentNullException("The recipeId is not valid.");
            }

            if (categoryId <= 0)
            {
                throw new ArgumentNullException("The categoryId is not valid.");
            }

            try
            {
                _recipeRepository.RemoveCategoryFromRecipe(categoryId, recipeId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public List<Recipe> GetAll()
        {
            List<Recipe> list = new List<Recipe>();

            try
            {
                list = _recipeRepository.GetAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return list;
        }

        public List<Recipe> GetRecipesByExpiredProduct(string userId, int productId)
        {
            List<Recipe> allRecipes = new List<Recipe>();

            List<UserProduct> userProducts = _userProductRepository.GetUserProducts(u => u.UserId == userId);

            try
            {
                allRecipes = _recipeRepository
                    .GetRecipes(r => r.RecipeProducts.Any(p => p.ProductId == productId))
                    .OrderByDescending(r => r.RecipeProducts.Count(p => userProducts.Any(up => up.ProductId == p.ProductId)))
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return allRecipes;
        }
    }
}
