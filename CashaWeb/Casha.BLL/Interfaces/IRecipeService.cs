using Casha.Core.DbModels;
using Casha.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Interfaces
{
    public interface IRecipeService
    {
        List<Recipe> GetRecipes(RecipeFilterDto recipeFilter);

        Recipe? GetRecipeByID(int recipeId);

        void AddRecipe(Recipe recipe);

        void DeleteRecipe(int recipeId);

        void UpdateRecipe(Recipe recipe);
    }
}
