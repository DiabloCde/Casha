using CashaMobile.Models;
using CashaMobile.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CashaMobile.ViewModels
{
    public class DetailedRecipeViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Categories { get; set; }
        public string DifficultyString { get; set; }
        public string ImageUrl { get; set; }
        public List<RecipeProduct> RecipeProducts { get; private set; }
        public string Instruction { get; set; }

        public string UserName { get; set; }
       
        

        public DetailedRecipeViewModel()
        {

            // Example
            Name = "Baked apples";
            Categories = "Dessert, Vegeterian";
            DifficultyString = Difficulty.Easy.ToString();
             ImageUrl = "https://sallysbakingaddiction.com/wp-content/uploads/2020/09/baked-apples-with-brown-sugar-oat-crumble.jpg";
            // ImageUrl = "https://www.themediterraneandish.com/wp-content/uploads/2021/09/baked-apples-recipes-7.jpg";
            RecipeProducts = new List<RecipeProduct>();
            RecipeProduct product = new RecipeProduct("apples", 4, Unit.piece);
            RecipeProduct product2 = new RecipeProduct("honey", 100, Unit.ml);
            RecipeProduct product3 = new RecipeProduct("nuts", 100, Unit.g);
            RecipeProducts.Add(product);
            RecipeProducts.Add(product2);
            RecipeProducts.Add(product3);
           
            UserName = "EugeneTheCook";
            Instruction = "Core the apples. Once the core is out, use a spoon to dig out any more seeds.\r\nPlace the apples into your baking dish. Once the apples are in the dish, fill them with the mixturre of honey and nuts.\r\nAdd warm liquid. To keep the apples moistened and to prevent them from burning\r\nBake. The baked apples take about 40-45 minutes";
            
        }
    }
}
