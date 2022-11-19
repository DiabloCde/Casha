using CashaMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CashaMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}