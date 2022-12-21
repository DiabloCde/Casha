using Casha.Core.DbModels;
using Casha.Core.Dtos;

namespace Casha.BLL.Interfaces
{
    public interface IRecipeService
    {
        List<Recipe> GetRecipes(RecipeFilterDto recipeFilter);

        List<Recipe> GetAll();

        Recipe? GetRecipeByID(int recipeId);

        void AddRecipe(Recipe recipe);

        void DeleteRecipe(int recipeId);

        void UpdateRecipe(Recipe recipe);

        void AddProductToRecipe(RecipeProduct recipeProduct);

        void RemoveProductFromRecipe(int productId, int recipeId);

        void UpdateProductInRecipe(RecipeProduct recipeProduct);

        void AddCategoryToRecipe(RecipeCategory recipeCategory);

        void RemoveCategoryFromRecipe(int categoryId, int recipeId);

        List<Recipe> GetRecipesWithAnyFridgeProduct(string userId);

        List<Recipe> GetRecipesWithAllFridgeProduct(string userId);

        List<Recipe> GetRecipesByExpiredProduct(string userId, int productId, int top);

        List<Recipe> GetRecipesByExpiredProducts(string userId);
    }
}
