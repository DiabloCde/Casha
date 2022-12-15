using CashaMobile.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashaMobile.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        public string Name { get; set; }

        public string RecipeImageUrl { get; set; }

        public Difficulty Difficulty { get; set; }

        public string Instruction { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public List<RecipeProduct> RecipeProducts { get; set; }

        public List<RecipeCategory> RecipeCategories { get; set; }

        public Recipe(string name, string recipeImageUrl, string instruction, List<RecipeProduct> recipeProducts)
        {
            Name = name;
            RecipeImageUrl = recipeImageUrl;
            Instruction = instruction;
            RecipeProducts = recipeProducts;

        }
    }
}
