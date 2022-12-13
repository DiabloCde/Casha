using CashaMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CashaMobile.ViewModels
{
    public class RecipesByProductViewModel
    {
        public ObservableCollection<RecipesCard> RecipesCards { get; private set; }

        private string selectedProductName;
        public string SelectedProductName
        {
            get { return selectedProductName; }
            private set { selectedProductName = value; }
        }

        private string searchLine;
        public string SearchLine
        {
            get { return searchLine; }
            set { searchLine = value; }
        }

        public RecipesByProductViewModel()
        {
            RecipesCards = new ObservableCollection<RecipesCard>();
            // Example
            // Produts
            ProductCard product1 = new ProductCard("Apple", ProductBackgroundColor.Green);
            ProductCard product2 = new ProductCard("Banana", ProductBackgroundColor.Green);
            ProductCard product3 = new ProductCard("Mushrooms", ProductBackgroundColor.Red);
            List<ProductCard> products1 = new List<ProductCard>();
            products1.Add(product1);
            products1.Add(product2);
            products1.Add(product3);
            // Fill RecipesCards
            RecipesCards.Add(new RecipesCard("Product example1", products1.AsEnumerable()));
            RecipesCards.Add(new RecipesCard("Product example2", products1.AsEnumerable()));
            RecipesCards.Add(new RecipesCard("Product example3", products1.AsEnumerable()));

            // Selected product name
            SelectedProductName = "Apple";
        }
    }
}
