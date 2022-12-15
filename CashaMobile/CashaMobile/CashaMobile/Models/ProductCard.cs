using System;
using System.Collections.Generic;
using System.Text;

namespace CashaMobile.Models
{
    public class ProductCard
    {
        private const string ProductInFridgeColor = "#B0F25C";
        private const string PrdouctNotInFridgeColor = "#FF1818";
        private const string ProductDisabledColor = "#989898";

        public string Name { get; set; }
        public string BackgroundColor { get; private set; }

        public ProductCard(string name, ProductBackgroundColor productBackgroundColor)
        {
            Name = name;
            BackgroundColor = SelectBackgroundColor(productBackgroundColor);
        }

        private string SelectBackgroundColor(ProductBackgroundColor productBackgroundColor)
        {
            switch (productBackgroundColor)
            {
                case ProductBackgroundColor.Green:
                    return ProductInFridgeColor;
                case ProductBackgroundColor.Red:
                    return PrdouctNotInFridgeColor;
                case ProductBackgroundColor.Disabled:
                    return ProductDisabledColor;
            }

            throw new Exception("Incorrect type of product backround color");
        }
    }
}
