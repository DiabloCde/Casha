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

            App.Current.Properties["ApiAddress"] = "http://192.168.1.239:5128/api/";
            App.Current.SavePropertiesAsync();

            MainPage = new DetailedRecipePage();
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
