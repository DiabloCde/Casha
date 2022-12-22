using CashaMobile.Models;
using CashaMobile.Services.Interfaces;
using CashaMobile.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace CashaMobile.ViewModels
{
    public class DetailedRecipeViewModel : ViewModelBase
    {
        private readonly IRecipeService _recipeService;
        private readonly RecipesCard _card;

        private string name;
        private string categories;
        private string difficultyString;
        private string imageUrl;
        private ObservableCollection<RecipeProduct> recipeProducts;
        private string instruction;
        private string userName;

        public string Name 
        { 
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Categories 
        { 
            get => categories; 
            set 
            {
                categories = value; OnPropertyChanged(nameof(Categories));
            }
        }
        public string DifficultyString 
        { 
            get => difficultyString; 
            set 
            {
                difficultyString = value; OnPropertyChanged(nameof(DifficultyString));
            }
        }
        public string ImageUrl 
        { 
            get => imageUrl; 
            set 
            {
                imageUrl = value;
                OnPropertyChanged(nameof(ImageUrl));
            }
        }
        public ObservableCollection<RecipeProduct> RecipeProducts 
        { 
            get => recipeProducts; 
            set
            {
                recipeProducts = value;
                OnPropertyChanged(nameof(RecipeProducts));
            }
        }
        public string Instruction 
        { 
            get => instruction; 
            set 
            {
                instruction = value;
                OnPropertyChanged(nameof(Instruction));
            }
        }
        public string UserName 
        { 
            get => userName; 
            set 
            {
                userName = value; 
                OnPropertyChanged(nameof(UserName));
            }
        }

        public ICommand LoadRecipe { get; set; }


        public DetailedRecipeViewModel(RecipesCard card)
        {
            _card = card;
            _recipeService = Startup.Resolve<IRecipeService>();

            RecipeProducts = new ObservableCollection<RecipeProduct>();
            LoadRecipe = new Command(async () => await OnLoadRecipe());


            //// Example
            //Name = "Baked apples";
            //Categories = "Dessert, Vegeterian";
            //DifficultyString = Difficulty.Easy.ToString();
            //ImageUrl = "https://sallysbakingaddiction.com/wp-content/uploads/2020/09/baked-apples-with-brown-sugar-oat-crumble.jpg";
            //// ImageUrl = "https://www.themediterraneandish.com/wp-content/uploads/2021/09/baked-apples-recipes-7.jpg";
            //RecipeProducts = new List<RecipeProduct>();
            //RecipeProduct product = new RecipeProduct("apples", 4, Unit.piece);
            //RecipeProduct product2 = new RecipeProduct("honey", 100, Unit.ml);
            //RecipeProduct product3 = new RecipeProduct("nuts", 100, Unit.g);
            //RecipeProducts.Add(product);
            //RecipeProducts.Add(product2);
            //RecipeProducts.Add(product3);

            //UserName = "EugeneTheCook";
            //Instruction = "Core the apples. Once the core is out, use a spoon to dig out any more seeds.\r\nPlace the apples into your baking dish. Once the apples are in the dish, fill them with the mixturre of honey and nuts.\r\nAdd warm liquid. To keep the apples moistened and to prevent them from burning\r\nBake. The baked apples take about 40-45 minutes";



        }

        protected async Task OnLoadRecipe()
        {
            try
            {
                var recipe = await _recipeService.GetRecipeByID(_card.RecipeId);

                Name = recipe.Name;
                DifficultyString = recipe.Difficulty.ToString();
                ImageUrl = recipe.RecipeImageUrl;
                UserName = recipe.UserName;
                Instruction = recipe.Instruction;
                
                RecipeProducts.Clear();

                foreach (var product in recipe.RecipeProducts)
                    RecipeProducts.Add(product);

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "An error occured" +
                    " while trying to perform ths operation " + ex.Message, "OK");
            }
        }  
    }
}
