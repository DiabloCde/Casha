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
                dbRecipe.RecipeImageUrl = recipe.RecipeImageUrl;
                dbRecipe.UserId = recipe.UserId;

                this._context.SaveChanges();
            }
        }

        public void AddProductToRecipe(RecipeProduct recipeProduct)
        {
            this._context.RecipeProducts.Add(recipeProduct);
            this._context.SaveChanges();
        }

        public List<RecipeProduct> GetRecipeProducts(Expression<Func<RecipeProduct, bool>> filter)
        {
            return this._context.RecipeProducts
                .Include(x => x.Product)
                .Include(x => x.Recipe)
                .Where(filter)
                .ToList();
        }

        public void RemoveProductFromRecipe(int productId, int recipeId)
        {
            RecipeProduct? recipeProduct = this._context.RecipeProducts
                .FirstOrDefault(x => x.ProductId == productId && x.RecipeId == recipeId);

            if (recipeProduct is not null)
            {
                this._context.RecipeProducts.Remove(recipeProduct);
                this._context.SaveChanges();
            }
        }

        public void UpdateProductInRecipe(RecipeProduct recipeProduct)
        {
            RecipeProduct? dbRecipeProduct = this._context.RecipeProducts
                .FirstOrDefault(x => x.ProductId == recipeProduct.ProductId && x.RecipeId == recipeProduct.RecipeId);

            if (dbRecipeProduct is not null)
            {
                dbRecipeProduct.Quantity = recipeProduct.Quantity;
                dbRecipeProduct.Unit = recipeProduct.Unit;

                this._context.SaveChanges();
            }
        }

        public List<RecipeCategory> GetRecipeCategories(Expression<Func<RecipeCategory, bool>> filter)
        {
            return this._context.RecipeCategories
                .Include(r => r.Recipe)
                .Include(c => c.Category)
                .Where(filter)
                .ToList();
        }

        public void AddCategoryToRecipe(RecipeCategory recipeCategory)
        {
            this._context.RecipeCategories.Add(recipeCategory);
            this._context.SaveChanges();
        }

        public void RemoveCategoryFromRecipe(int categoryId, int recipeId)
        {
            RecipeCategory? recipeCategory = this._context.RecipeCategories
                .FirstOrDefault(x => x.CategoryId == categoryId && x.RecipeId == recipeId);

            if (recipeCategory is not null)
            {
                this._context.RecipeCategories.Remove(recipeCategory);
                this._context.SaveChanges();
            }
        }

        public List<Recipe> GetAll()
        {
            List<Recipe> list = _context.Recipes
                .Include(x => x.User)
                .Include(x => x.RecipeProducts)
                .ThenInclude(x=>x.Product)
                .Include(x => x.RecipeCategories)
                .ThenInclude(x=>x.Category).ToList();

            return list;
        }
    }
}
