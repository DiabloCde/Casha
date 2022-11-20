using Casha.Core.DbModels;
using Casha.Core.Enums;

namespace CashaWeb.ViewModels
{
    public class RecipeCategoryViewModel
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public CategoryType CategoryType { get; set; }

        public int RecipeId { get; set; }
    }
}