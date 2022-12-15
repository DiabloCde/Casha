using CashaMobile.Models;
using CashaMobile.Services.Interfaces;
using CashaMobile.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CashaMobile.ViewModels
{
    public class UserProductViewModel : ViewModelBase
    {
        private IUserProductService _userProductService;
        private UserProduct _userProduct;

        public UserProductViewModel(IUserProductService userProductService)
        {
            _userProductService = userProductService;

            DiscardUserProduct = new Command(OnDiscardUserProduct);
        }

        public UserProduct UserProduct
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

        public async Task OnCreateUserProduct()
        {
            await _userProductService.AddUserProduct(UserProduct);
            ToFridge();
        }

        private void ToFridge()
        {
            App.Current.MainPage = new FridgePage();
        }
    }
}
