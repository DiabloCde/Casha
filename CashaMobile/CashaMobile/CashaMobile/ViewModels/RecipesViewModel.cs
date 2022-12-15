using System;
using System.Collections.Generic;
using System.Text;
using CashaMobile.Models.Enums;
using System.Linq;
using CashaMobile.Helpers;
using CashaMobile.Services.Interfaces;
using CashaMobile.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace CashaMobile.ViewModels
{
    public class RecipesViewModel : ViewModelBase
    {
        private readonly IRecipeService _recipeService;

        private RecipeFilter _filter;
        private string _searchQuery;
        private ObservableCollection<RecipesCard> _recipesCards; 
        private List<UserProduct> _userProducts;
        
        public RecipeFilter Filter
        {
            get { return _filter; }
            set 
            { 
                _filter = value;
                OnPropertyChanged(nameof(Filter));
            }
        }

        public string SearchQuery
        {
            get { return _searchQuery; }
            set 
            { 
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery)); 
            }
        }

        public List<string> FilterValues
        {
            get
            {
                return Enum.GetNames(typeof(RecipeFilter))
                    .Select(b => b.SplitCamelCase()).ToList();
            }
        }

        public ObservableCollection<RecipesCard> RecipesCards
        {
            get { return _recipesCards; }
            set
            {
                _recipesCards = value;
                OnPropertyChanged(nameof(RecipesCards));
            }
        } 

        public ICommand FiltreRecipes { get; set; }


        public RecipesViewModel(IRecipeService recipeService, IUserProductService userProductService)
        {
            _recipeService = recipeService;

            RecipesCards = new ObservableCollection<RecipesCard>();
            Filter = RecipeFilter.IncludeAll;
            SearchQuery = "";

            FiltreRecipes = new Command(async () => await OnFiltreRecipes());

            InitUserProducts(userProductService);
        }

        protected async Task OnFiltreRecipes()
        {
            try
            {
                IEnumerable<Recipe> newRecipes = null;

                //newRecipes = _recipeService.FiltreRecipes(SearchQuery, Filter);

                Console.WriteLine(SearchQuery);
                Console.WriteLine(Filter);

                RecipesCards.Clear();

                if (newRecipes is null || newRecipes.Count() == 0)
                {
                    RecipesCards.Add(RecipesCard.Empty());
                }
                else
                {
                    foreach(var recipe in newRecipes)
                    {
                        var recipeCards = recipe.RecipeProducts
                            .Select(p => GetCard(p));

                        RecipesCards.Add(new RecipesCard(recipe.Name, recipeCards));
                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error",
                    "An error occured while trying to load recipes. " + ex.Message, "OK");
            }
        }

        private ProductCard GetCard(RecipeProduct recipeProduct)
        {
            var color = ProductBackgroundColor.Disabled;

            if (_userProducts.Any(p => p.ProductId == recipeProduct.ProductId))
                color = ProductBackgroundColor.Green;
            else 
                color = ProductBackgroundColor.Red;

            return new ProductCard(recipeProduct.ProductName, color);
        }

        private async Task InitUserProducts(IUserProductService userProductService)
        {
            string userId = App.Current.Properties["userId"].ToString();
            _userProducts = await userProductService.GetUserProductsByUserId(userId);
        }
    }
}
