using Casha.Core.Enums;

namespace CashaWeb.ViewModels
{
    public class RecipeListViewModel
    {
        public int RecipeId { get; set; }

        public string Name { get; set; }

        public string RecipeImageUrl { get; set; }

        public Difficulty Difficulty { get; set; }

        public string UserId { get; set; }
        
        public string UserName { get; set; }

    }
}
