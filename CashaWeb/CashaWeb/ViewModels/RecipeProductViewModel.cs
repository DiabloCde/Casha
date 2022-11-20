using Casha.Core.DbModels;
using Casha.Core.Enums;

namespace CashaWeb.ViewModels
{
    public class RecipeProductViewModel
    {
        public int RecipeId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; } 

        public double Quantity { get; set; }

        public Unit Unit { get; set; }
    }
}