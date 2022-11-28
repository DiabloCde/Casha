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

            LoadUserProducts = new Command(() => OnLoadUserProducts());
            AddUserProduct = new Command(() => Console.WriteLine("Added"));
            DeleteUserProduct = new Command((id) => Console.WriteLine("Delete: " + id.ToString()));
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

    }
}
