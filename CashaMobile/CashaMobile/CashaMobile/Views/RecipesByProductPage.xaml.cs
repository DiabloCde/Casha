using CashaMobile.Models;
using CashaMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CashaMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesByProductPage : ContentPage
    {
        public RecipesByProductViewModel ViewModel { get; set; }
        public RecipesByProductPage()
        {
            InitializeComponent();
            ViewModel = new RecipesByProductViewModel();
            BindingContext = ViewModel;
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            ViewCell viewCell = sender as ViewCell;
            RecipesCard card = (RecipesCard)viewCell.BindingContext;
            // You can get RecipesCard to ViewModel by clicking on item in list of RecipesCards
            // Console.WriteLine(card.RecipeName);
        }
    }
}