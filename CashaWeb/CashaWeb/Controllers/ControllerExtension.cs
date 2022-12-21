using Casha.Core.DbModels;
using CashaWeb.ViewModels;

namespace CashaWeb.Controllers
{
    public static class ControllerExtension
    {
        public static List<RecipeViewModel> MapRecipesToView(this List<Recipe> recipes)
        {
            return recipes.Select(recipe => new RecipeViewModel
            {
                RecipeId = recipe.RecipeId,
                Name = recipe.Name,
                RecipeImageUrl = recipe.RecipeImageUrl,
                Difficulty = recipe.Difficulty,
                Instruction = recipe.Instruction,
                UserId = recipe.UserId,
                UserName = recipe.User.DisplayName,
                RecipeCategories = recipe.RecipeCategories.Select(r => new RecipeCategoryViewModel
                {
                    CategoryId = r.CategoryId,
                    CategoryName = r.Category.CategoryName,
                    CategoryType = r.Category.CategoryType,
                    RecipeId = r.RecipeId
                }).ToList(),
                RecipeProducts = recipe.RecipeProducts.Select(r => new RecipeProductViewModel
                {
                    RecipeId = r.RecipeId,
                    ProductId = r.ProductId,
                    ProductName = r.Product.Name,
                    Quantity = r.Quantity,
                    Unit = r.Unit
                }).ToList()
            }).ToList();
        }
    }
}
