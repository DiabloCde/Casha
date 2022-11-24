using Casha.BLL.Interfaces;
using Casha.Core.DbModels;
using Casha.Core.Enums;
using CashaWeb.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace CashaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                List<Product> products = this._productService.GetAllProducts();

                List<ProductViewModel> productViewModels = products.Select(c => new ProductViewModel
                {
                    ProductId = c.ProductId,
                    Name = c.Name
                }).ToList();

                return Ok(productViewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{productId}")]
        public IActionResult GetProductByID([FromRoute] int productId)
        {
            try
            {
                Product? product = this._productService.GetProductByID(productId);

                if (product is null)
                {
                    return NotFound();
                }

                ProductViewModel productViewModel = new ProductViewModel
                {
                    ProductId = product.ProductId,
                    Name = product.Name
                };

                return Ok(productViewModel);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex.Message);

                return ValidationProblem(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductCreateModel productCreateModel)
        {
            try
            {
                Product product = new Product
                {
                    Name = productCreateModel.Name,
                };

                this._productService.AddProduct(product);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct([FromRoute] int productId)
        {
            try
            {
                this._productService.DeleteProduct(productId);

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex.Message);

                return ValidationProblem(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(
            [FromRoute]
            int productId,
            [FromBody]
            ProductCreateModel productCreateModel)
        {
            try
            {
                Product product = new Product
                {
                    ProductId = productId,
                    Name = productCreateModel.Name
                };

                this._productService.UpdateProduct(product);

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex.Message);

                return ValidationProblem(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
