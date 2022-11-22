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
        // view model need to ne added
        //public RegisterViewModel viewModel;

        public RegisterPage()
        {
            InitializeComponent();

            // view model need to ne added as dependency injection 
            //viewModel = Startup.Resolve<RegisterViewModel>();

            // DisplayInvalidRegisterPrompt view model need to ne added
            //viewModel.DisplayInvalidRegisterPrompt = () =>
            //{
            //    DisplayAlert("Register error", "There is error during register", "Ok");
            //};

            //BindingContext = viewModel;

            Login.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                PasswordRep.Focus();
            };

            PasswordRep.Completed += (object sender, EventArgs e) =>
            {
                // SubmitCommand in view model need to ne added
                // viewModel.SubmitCommand.Execute(null);
            };
        }
    }
}