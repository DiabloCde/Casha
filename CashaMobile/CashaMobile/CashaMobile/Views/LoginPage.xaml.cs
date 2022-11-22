using CashaMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashaMobile.Services;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CashaMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel viewModel;

        public LoginPage()
        {
            InitializeComponent();

            viewModel = Startup.Resolve<LoginViewModel>();
            BindingContext = viewModel;

            //var client = new HttpClient();
            //client.BaseAddress = new Uri(App.Current.Properties["ApiAdress"].ToString());

            //viewModel = new LoginViewModel(new AccountService(new HttpClient()));


            Login.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                viewModel.SubmitCommand.Execute(null);
            };
        }
    }
}