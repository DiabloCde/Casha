using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashaMobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CashaMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FridgePage : ContentPage
    {
        public FridgeViewModel viewModel;

        public FridgePage()
        {
            InitializeComponent();

            viewModel = Startup.Resolve<FridgeViewModel>();

            BindingContext = viewModel;

            AddButton.Command = new Command(() => Console.WriteLine("Click"));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadUserProducts.Execute(null);
        }

    }
}