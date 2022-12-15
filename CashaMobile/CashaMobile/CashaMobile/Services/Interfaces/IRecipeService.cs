using CashaMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashaMobile.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<Recipe> GetRecipeByID(int recipeId);
        Task<List<Recipe>> GetRecipesByProductd(string userId, int productId);
    }
}
