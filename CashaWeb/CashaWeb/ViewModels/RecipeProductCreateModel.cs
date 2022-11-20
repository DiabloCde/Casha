using Casha.Core.Enums;

namespace CashaWeb.ViewModels
{
    public class RecipeProductCreateModel
    {
        public int ProductId { get; set; }

        public double Quantity { get; set; }

        public Unit Unit { get; set; }
    }
}
