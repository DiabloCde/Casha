using CashaMobile.Models;
using System.Collections.Generic;
using System.Linq;

namespace CashaMobile.Services
{
    public static class RecipeExtension
    {
        public static ICollection<Recipe> FindRecipeByName(this ICollection<Recipe> recipes, string name)
        {
            return recipes.Where(r => r.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
