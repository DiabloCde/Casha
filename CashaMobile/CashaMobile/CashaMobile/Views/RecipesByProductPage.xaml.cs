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
        public RecipesByProductPage(UserProduct userProduct)
        {
            InitializeComponent();
            ViewModel = new RecipesByProductViewModel(userProduct);
            BindingContext = ViewModel;
        }
    }
}