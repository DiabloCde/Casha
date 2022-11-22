using CashaMobile.Services.Interfaces;
using CashaMobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CashaMobile.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged  
    {
        public Action DisplayInvalidLoginPrompt;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Login"));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }

        public ICommand ToRegisterCommand { protected set; get; }

        private readonly IAccountService _accountService;

        public LoginViewModel(IAccountService accountService)
        {
            SubmitCommand = new Command(OnSubmit);
            ToRegisterCommand = new Command(OnToRegister);
            _accountService = accountService;
        }

        public async void OnSubmit()
        {
            if (!await _accountService.LoginAsync(login, password))
            {
                DisplayInvalidLoginPrompt();
            }
        }

        public void OnToRegister()
        {
            App.Current.MainPage = new RegisterPage(); 
        }


    }
}
