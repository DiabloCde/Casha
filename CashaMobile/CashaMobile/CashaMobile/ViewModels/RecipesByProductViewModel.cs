using CashaMobile.Models;
using CashaMobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CashaMobile.ViewModels
{
    public class RecipesByProductViewModel : ViewModelBase
    {
        private readonly IRecipeService _recipeService;

        private readonly IUserProductService _userProductService;
        public UserProduct UserProduct { get; set; }
        public ObservableCollection<RecipesCard> RecipesCards { get; private set; }

        public ICommand LoadRecipes { get; protected set; }

        public ICommand SearchCommand { get; protected set; }

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
            set 
            { 
                searchLine = value;
                OnPropertyChanged();
            }
        }

        public RecipesByProductViewModel(IRecipeService recipeService,IUserProductService userProductService)
        {
            _recipeService = recipeService;
            _userProductService = userProductService; 
            RecipesCards = new ObservableCollection<RecipesCard>();

            LoadRecipes = new Command(async () => await OnLoadRecipes());
            SearchCommand = new Command(OnSearch);
        }

        private async Task OnLoadRecipes()
        {
            SelectedProductName = UserProduct.ProductName;
            var userProducts = await _userProductService.GetUserProductsByUserId(UserProduct.UserId);
            var recipes = await _recipeService.GetRecipesByProductd(UserProduct.UserId, UserProduct.ProductId);

            foreach(Recipe recipe in recipes)
            {
                List<ProductCard> productCards = new List<ProductCard>();
                foreach(RecipeProduct recipeProduct in recipe.RecipeProducts)
                {
                    var color = isProductContainsInRecipe(userProducts, recipeProduct) ? ProductBackgroundColor.Green : ProductBackgroundColor.Red;
                    productCards.Add(new ProductCard(recipeProduct.ProductName, color));   
                }

                RecipesCards.Add(new RecipesCard(recipe.Name, productCards.AsEnumerable()));
            }
        }

        private bool isProductContainsInRecipe(List<UserProduct> userProducts, RecipeProduct recipeProduct)
        {
            foreach (UserProduct userProduct in userProducts)
            {
                if(userProduct.ProductName == recipeProduct.ProductName)
                {
                    return true;
                }
            }

            return false;
        }

        public void OnSearch()
        {
            try
            {
                var filtered = RecipesCards.Where(rc => rc.RecipeName.Contains(SearchLine)).ToList();
                RecipesCards.Clear();
                foreach(RecipesCard recipesCard in filtered)
                {
                    RecipesCards.Add(recipesCard);
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);   
            }
        }

    }
}
