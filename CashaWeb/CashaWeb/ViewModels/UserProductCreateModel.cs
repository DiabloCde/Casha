using Casha.Core.Enums;

namespace CashaWeb.ViewModels
{
    public class UserProductCreateModel
    {
        public string UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Unit Unit { get; set; }
    }
}
