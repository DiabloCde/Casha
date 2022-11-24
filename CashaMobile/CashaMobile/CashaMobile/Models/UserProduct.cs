using System;
using System.Collections.Generic;
using System.Text;

namespace CashaMobile.Models
{
    public class UserProduct
    {
        public int UserProductId { get; set; }

        public string UserId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
