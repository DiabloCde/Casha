using System;
using System.Collections.Generic;
using System.Text;
using CashaMobile.Services.Interfaces;
using System.Collections.ObjectModel;
using CashaMobile.Models;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using CashaMobile.Views;

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
            ShowRecipes = new Command(async (selected) => await OnShowRecipes(selected));
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
        public ICommand AddUserProduct { get; protected set; }
        public ICommand DeleteUserProduct { get; protected set; }
        public ICommand ShowRecipes { get; protected set; }


        public async Task OnLoadUserProducts()
        {
            IsListRefreshing = true;

            string userId = App.Current.Properties["userId"].ToString();
            List<UserProduct> userProducts =
                await _userProductService.GetUserProductsByUserId(userId);
            UserProducts.Clear();

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
        
        public async Task OnShowRecipes(object productObj)
        {
            try
            {
                var product = productObj as UserProduct;

                // Example of page transition
                await App.Current.MainPage.Navigation
                    .PushAsync(new RecipesByProductPage(product));
                // If backwards transition is required, use Navigation.PopAsync(); 
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "An error occured" +
                    " while trying to perform ths operation " + ex.Message, "OK");
            }
        }
    }
}
