using CashaMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CashaMobile.Models;

namespace CashaMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailedRecipePage : ContentPage
    { 
        public DetailedRecipeViewModel ViewModel { get; set; }
    
        public DetailedRecipePage(RecipesCard card)
        {
            InitializeComponent();
            ViewModel = new DetailedRecipeViewModel(card);
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.LoadRecipe.Execute(null);
        }

    }
}