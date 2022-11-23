using CashaMobile.Services.Interfaces;
using CashaMobile.Views;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CashaMobile.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidRegisterPrompt;

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

        private string passwordConfirm;
        public string PasswordConfirm
        {
            get { return passwordConfirm; }
            set
            {
                passwordConfirm = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PasswordConfirm"));
            }
        }

        public ICommand SubmitCommand { protected set; get; }

        public ICommand ToLoginCommand { protected set; get; }

        private readonly IAccountService _accountService;

        public RegisterViewModel(IAccountService accountService)
        {
            SubmitCommand = new Command(OnSubmit);
            ToLoginCommand = new Command(OnToLogin);
            _accountService = accountService;
        }

        public async void OnSubmit()
        {
            if (!await _accountService.RegiterAsync(login, password, passwordConfirm))
            {
                DisplayInvalidRegisterPrompt();
            }
            else
            {
                OnToLogin();
            }
        }

        public void OnToLogin()
        {
            App.Current.MainPage = new LoginPage();
        }
    }
}
