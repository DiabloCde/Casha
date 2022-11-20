using Casha.Core.Enums;

namespace CashaWeb.ViewModels
{
    public class RecipeUpdateModel 
    {
        public int RecipeId { get; set; }

        public string Name { get; set; }

        public string RecipeImageUrl { get; set; }

        public Difficulty Difficulty { get; set; }

        public string Instruction { get; set; }

        public string UserId { get; set; }

        public List<RecipeProductUpdateModel> RecipeProducts { get; set; }

        public List<RecipeCategoryUpdateModel> RecipeCategories { get; set; }
    }
}
