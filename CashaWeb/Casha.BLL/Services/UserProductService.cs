using Casha.BLL.Interfaces;
using Casha.Core.DbModels;
using Casha.Core.Enums;
using Casha.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Services
{
    public class UserProductService : IUserProductService
    {
        private readonly IUserProductRepository _userProductRepository;

        private readonly ILogger<UserProductService> _logger;

        public UserProductService(IUserProductRepository userProductRepository, ILogger<UserProductService> logger)
        {
            _userProductRepository = userProductRepository;
            _logger = logger;
        }

        public void AddUserProduct(UserProduct userProduct)
        {
            try
            {
                this._userProductRepository.InsertUserProduct(userProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void DeleteUserProduct(int userProductId)
        {
            if (userProductId <= 0)
            {
                throw new ArgumentNullException("The userProductId is not valid.");
            }

            try
            {
                this._userProductRepository.DeleteUserProduct(userProductId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public List<UserProduct> GetAllUserProducts()
        {
            try
            {
                return this._userProductRepository.GetUserProducts(c => c.UserProductId > 0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new List<UserProduct>();
            }
        }
        
        public UserProduct? GetUserProductByID(int userProductId)
        {
            if (userProductId <= 0)
            {
                throw new ArgumentNullException("The userProductId is not valid.");
            }

            try
            {
                return this._userProductRepository.GetUserProductByID(userProductId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return null;
            }
        }

        public List<UserProduct> GetUserProductsByUserId(string userId)
        {
            if (userId == "")
            {
                throw new ArgumentNullException("The UserId is not valid.");
            }

            try
            {
                return this._userProductRepository.GetUserProducts(i => i.UserId == userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new List<UserProduct>();
            }
        }

        public void UpdateUserProduct(UserProduct userProduct)
        {
            if (userProduct.UserProductId <= 0)
            {
                throw new ArgumentNullException("The userProductId is not valid.");
            }

            try
            {
                this._userProductRepository.UpdateUserProduct(userProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
