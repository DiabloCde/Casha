using Casha.Core.DbModels;
using Casha.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.DAL.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationContext _context;

        public RecipeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void DeleteRecipe(int recipeId)
        {
            Recipe? recipe = this._context.Recipes.Find(recipeId);

            if (recipe is not null)
            {
                this._context.Recipes.Remove(recipe);
                this._context.SaveChanges();
            }
        }

        public List<Recipe> GetRecipes(Expression<Func<Recipe, bool>> filter)
        {
            return this._context.Recipes
                .Include(x => x.User)
                .Include(x => x.RecipeProducts)
                .Include(x => x.RecipeCategories)
                .Where(filter).ToList();
        }

        public Recipe? GetRecipeByID(int recipeId)
        {
            return this._context.Recipes
                .Include(x => x.User)
                .Include(x => x.RecipeProducts)
                .Include(x => x.RecipeCategories)
                .FirstOrDefault(x => x.RecipeId == recipeId);
        }

        public void InsertRecipe(Recipe recipe)
        {
            this._context.Recipes.Add(recipe);
            this._context.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            Recipe? dbRecipe = this._context.Recipes.Find(recipe.RecipeId);

            if (dbRecipe is not null)
            {
                dbRecipe.Name = recipe.Name;
                dbRecipe.Instruction = recipe.Instruction;
                dbRecipe.Difficulty = recipe.Difficulty;
                dbRecipe.UserId = recipe.UserId;

                this._context.SaveChanges();
            }
        }
    }
}
