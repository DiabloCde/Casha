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
    public partial class DetailedRecipePage : ContentPage
    { 
        public DetailedRecipeViewModel ViewModel { get; set; }
    
        public DetailedRecipePage()
        {
            InitializeComponent();
            ViewModel = new DetailedRecipeViewModel();
            BindingContext = ViewModel;
            
        }

    }
}