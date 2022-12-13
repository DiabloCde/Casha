using CashaMobile.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashaMobile.Models
{
    public class RecipeProduct
    {
        public int RecipeId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double Quantity { get; set; }

        public Unit Unit { get; set; }
    }
}
