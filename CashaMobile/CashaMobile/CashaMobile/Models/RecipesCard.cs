using System;
using System.Collections.Generic;
using System.Text;

namespace CashaMobile.Models
{
    public class RecipesCard
    {
        private const int MaxNumberOfDisplayedItems = 3;

        public string RecipeName { get; private set; }

        public ProductCard FirstProductView { get; private set; }
        public ProductCard SecondProductView { get; private set; }
        public ProductCard ThirdProductView { get; private set; }

        public RecipesCard(string recipeName, IEnumerable<ProductCard> items)
        {
            RecipeName = recipeName;
            InitializeItems(items);
        }

        public static RecipesCard Empty()
        {
            return new RecipesCard("No matching recipes", 
                new List<ProductCard>
                {
                    new ProductCard("empty", ProductBackgroundColor.Disabled),
                    new ProductCard("empty", ProductBackgroundColor.Disabled),
                    new ProductCard("empty", ProductBackgroundColor.Disabled),
                }
            );
        }

        private void InitializeItems(IEnumerable<ProductCard> items)
        {
            if (Count(items) < MaxNumberOfDisplayedItems)
            {
                throw new Exception("Product cars less then 3");
            }

            List<ProductCard> productCards = new List<ProductCard>();
            productCards.AddRange(items);

            FirstProductView = productCards[0];
            SecondProductView = productCards[1];
            ThirdProductView = productCards[2];
        }

        private int Count(IEnumerable<ProductCard> items)
        {
            int count = 0;
            foreach (var item in items)
            {
                count++;
            }
            return count;
        }
    }
}
