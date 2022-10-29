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

        Recipe? GetRecipeByID(int recipeId);

        void InsertRecipe(Recipe recipe);

        void DeleteRecipe(int recipeId);

        void UpdateRecipe(Recipe recipe);
    }
}
