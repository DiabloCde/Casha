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
    public partial class RegisterPage : ContentPage
    {
        public RegisterViewModel viewModel;

        public RegisterPage()
        {
            InitializeComponent();

            viewModel = Startup.Resolve<RegisterViewModel>();

            viewModel.DisplayInvalidRegisterPrompt = () =>
            {
                DisplayAlert("Register error", "There is error during register", "Ok");
            };

            BindingContext = viewModel;

            Login.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                PasswordConfirm.Focus();
            };

            PasswordConfirm.Completed += (object sender, EventArgs e) =>
            {
                viewModel.SubmitCommand.Execute(null);
            };
        }
    }
}