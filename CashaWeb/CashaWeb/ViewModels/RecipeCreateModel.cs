using Casha.Core.Enums;

namespace CashaWeb.ViewModels
{
    public class RecipeCreateModel
    {
        public string Name { get; set; }

        public string RecipeImageUrl { get; set; }

        public Difficulty Difficulty { get; set; }

        public string Instruction { get; set; }

        public string UserId { get; set; }

        public List<RecipeProductCreateModel> RecipeProducts { get; set; }

        public List<int> RecipeCategories { get; set; }
    }
}