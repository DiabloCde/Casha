using CashaMobile.Models;
using CashaMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CashaMobile.Views;

namespace CashaMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesByProductPage : ContentPage
    {
        public RecipesByProductViewModel ViewModel { get; set; }
        public RecipesByProductPage(UserProduct userProduct)
        {
            InitializeComponent();
            ViewModel = Startup.Resolve<RecipesByProductViewModel>();
            ViewModel.UserProduct = userProduct;
            BindingContext = ViewModel;
        }

        private void Search(object sender, EventArgs e)
        {
            var SearchString = searchBar.Text;
            Console.WriteLine(SearchString);
        }
        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            ViewCell viewCell = sender as ViewCell;
            RecipesCard card = (RecipesCard)viewCell.BindingContext;

            App.Current.MainPage.Navigation
                .PushAsync(new DetailedRecipePage(card));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.LoadRecipes.Execute(null);
        }
    }
}