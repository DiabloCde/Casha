using System;
using System.Collections.Generic;
using System.Text;
using CashaMobile.Services.Interfaces;
using System.Collections.ObjectModel;
using CashaMobile.Models;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace CashaMobile.ViewModels
{
    public class FridgeViewModel : ViewModelBase
    {
        private readonly IUserProductService _userProductService;
        private ObservableCollection<UserProduct> _userProducts;
        private bool _isListRefreshing;

        public FridgeViewModel(IUserProductService userProductService)
        {
            _userProductService = userProductService;
            _userProducts = new ObservableCollection<UserProduct>();

            LoadUserProducts = new Command(async () => await OnLoadUserProducts());
            AddUserProduct = new Command(OnAddUserProduct);
            DeleteUserProduct = new Command(async (userProductId) => await OnDeleteUserProduct((int)userProductId));
        }

        public ObservableCollection<UserProduct> UserProducts
        {
            get => _userProducts;
            set
            {
                _userProducts = value;
                OnPropertyChanged("UserProducts");
            }
        }

        public bool IsListRefreshing
        {
            get => _isListRefreshing;
            set
            {
                _isListRefreshing = value;
                OnPropertyChanged("IsListRefreshing");
            }
        }

        public ICommand LoadUserProducts { get; protected set; }
        public ICommand OpenUserProductInfo { get; protected set; }
        public ICommand AddUserProduct { get; protected set; }
        public ICommand DeleteUserProduct { get; protected set; }
        public ICommand SelectUserProduct { get; protected set; }


        public async Task OnLoadUserProducts()
        {
            IsListRefreshing = true;
            UserProducts.Clear();

            string userId = App.Current.Properties["userId"].ToString();
            List<UserProduct> userProducts =
                await _userProductService.GetUserProductsByUserId(userId);

            foreach (UserProduct item in userProducts)
            {
                UserProducts.Add(item);
                Console.WriteLine(item.ProductName);
            }

            IsListRefreshing = false;
        }

        public async Task OnDeleteUserProduct(int userProductId)
        {
            await _userProductService.DeleteUserProduct(userProductId);

            await OnLoadUserProducts();
        }

        public void OnAddUserProduct()
        {
            //App.Current.MainPage = new UserProductPage();
        }
    }
}
