using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casha.BLL.Interfaces;
using Casha.Core.DbModels;
using Casha.Core.Enums;
using Casha.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace Casha.BLL.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public void AddProduct(Product product)
        {
            try
            {
                _productRepository.InsertProduct(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public void DeleteProduct(int productId)
        {
            if (productId < 0)
            {
                throw new ArgumentNullException("ProductId is not valid.");
            }

            try
            {
                _productRepository.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                return _productRepository.GetProducts(p => p.ProductId > 0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new List<Product>();
            }
        }

        public Product? GetProductByID(int productId)
        {
            if (productId < 0)
            {
                throw new ArgumentNullException("ProductId is not valid.");
            }

            try
            {
                return _productRepository.GetProductByID(productId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return null;
            }
        }

        public void UpdateProduct(Product product)
        {
            if (product.ProductId < 0)
            {
                throw new ArgumentNullException("ProductId is not valid.");
            }

            try
            {
                _productRepository.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
