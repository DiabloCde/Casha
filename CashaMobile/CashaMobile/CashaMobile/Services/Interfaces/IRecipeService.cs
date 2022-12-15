using CashaMobile.Models;
using CashaMobile.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashaMobile.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<Recipe> GetRecipeByID(int recipeId);

        Task<ICollection<Recipe>> GetRecipesByFilter(RecipeFilter filter, string name = null);
    }
}
