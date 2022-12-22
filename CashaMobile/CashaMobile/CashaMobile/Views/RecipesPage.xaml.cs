using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CashaMobile.ViewModels;
using CashaMobile.Models.Enums;
using CashaMobile.Models;

namespace CashaMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesPage : ContentPage
    {
        public RecipesViewModel ViewModel { get; set; }

        public RecipesPage()
        {
            InitializeComponent();

            ViewModel = Startup.Resolve<RecipesViewModel>();
            BindingContext = ViewModel;
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

            ViewModel.FiltreRecipes.Execute(null);
        }
    }
}