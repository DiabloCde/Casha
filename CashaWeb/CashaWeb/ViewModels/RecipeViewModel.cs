using Casha.Core.DbModels;
using Casha.Core.Enums;

namespace CashaWeb.ViewModels
{
    public class RecipeViewModel
    {
        public int RecipeId { get; set; }

        public string Name { get; set; }

        public string RecipeImageUrl { get; set; }

        public Difficulty Difficulty { get; set; }

        public string Instruction { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public List<RecipeProductViewModel> RecipeProducts { get; set; }

        public List<RecipeCategoryViewModel> RecipeCategories { get; set; }
    }
}
