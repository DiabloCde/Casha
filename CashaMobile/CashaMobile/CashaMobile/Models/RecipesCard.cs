using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            for (int i = 0; i < MaxNumberOfDisplayedItems; ++i)
            {
                if (items.Count() >= i + 1)
                    InitializeItem(items.ElementAt(i), i);
                else
                    InitializeItem(ProductCard.Empty(), i);
            }
        }

        private void InitializeItem(ProductCard item, int index)
        {
            switch(index)
            {
                case 0:
                    FirstProductView = item;
                    break;
                case 1:
                    SecondProductView = item;
                    break;
                case 2:
                    ThirdProductView = item;
                    break;
            }
        }
    }
}
