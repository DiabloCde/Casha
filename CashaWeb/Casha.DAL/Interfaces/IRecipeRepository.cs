using Casha.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.DAL.Interfaces
{
    public interface IRecipeRepository
    {
        List<Recipe> GetRecipes(Expression<Func<Recipe, bool>> filter);

        List<Recipe> GetAll();

        Recipe? GetRecipeByID(int recipeId);

        void InsertRecipe(Recipe recipe);

        void DeleteRecipe(int recipeId);

        void UpdateRecipe(Recipe recipe);

        List<RecipeProduct> GetRecipeProducts(Expression<Func<RecipeProduct, bool>> filter);

        void AddProductToRecipe(RecipeProduct recipeProduct);

        void RemoveProductFromRecipe(int productId, int recipeId);

        void UpdateProductInRecipe(RecipeProduct recipeProduct);

        List<RecipeCategory> GetRecipeCategories(Expression<Func<RecipeCategory, bool>> filter);

        void AddCategoryToRecipe(RecipeCategory recipeCategory);

        void RemoveCategoryFromRecipe(int categoryId, int recipeId);
    }
}
