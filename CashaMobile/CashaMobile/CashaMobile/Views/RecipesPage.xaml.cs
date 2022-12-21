using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CashaMobile.ViewModels;
using CashaMobile.Models.Enums;

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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.FiltreRecipes.Execute(null);
        }
    }
}