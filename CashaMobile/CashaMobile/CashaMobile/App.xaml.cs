using CashaMobile.Services;
using CashaMobile.Services.Interfaces;
using CashaMobile.ViewModels;
using CashaMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CashaMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Startup.Init();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
