using CashaMobile.Models;
using CashaMobile.Services.Interfaces;
using CashaMobile.Views;
using System.Windows.Input;

namespace CashaMobile.ViewModels
{
    public class UserProductViewModel : ViewModelBase
    {
        private IUserProductService _userProductService;
        private UserProduct _userProduct;

        public UserProductViewModel(IUserProductService userProductService)
        {
            _userProductService = userProductService;
        }

        private UserProduct UserProduct
        {
            get => _userProduct;
            set
            {
                _userProduct = value;
                OnPropertyChanged("UserProduct");
            }
        }

        public ICommand CreateUserProduct { get; protected set; }
        public ICommand DiscardUserProduct { get; protected set; }

        public void OnDiscardUserProduct()
        {
            App.Current.MainPage = new FridgePage();
        }
    }
}
