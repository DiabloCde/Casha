﻿using CashaMobile.Models;
using CashaMobile.Services.Interfaces;

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
    }
}
