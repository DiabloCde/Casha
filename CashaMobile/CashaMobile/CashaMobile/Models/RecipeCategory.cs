using CashaMobile.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashaMobile.Models
{
    public class RecipeCategory
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public CategoryType CategoryType { get; set; }

        public int RecipeId { get; set; }
    }
}
