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
    public class UserProductController : ControllerBase
    {
        private readonly IUserProductService _userProductService;

        private readonly ILogger<UserProductController> _logger;

        public UserProductController(IUserProductService userProductService, ILogger<UserProductController> logger)
        {
            _userProductService = userProductService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllUserProducts()
        {
            try
            {
                List<UserProduct> userProducts = this._userProductService.GetAllUserProducts();

                List<UserProductViewModel> userProductViewModels = userProducts.Select(c => new UserProductViewModel
                {
                    UserProductId = c.UserProductId,
                    UserId = c.UserId,
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    ExpirationDate = c.ExpirationDate,
                    ProductName = c.Product.Name,

                }).ToList();

                return Ok(userProductViewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("User/{userId}")]
        public IActionResult GetUserProductsByUserId([FromRoute] string userId)
        {
            try
            {
                List<UserProduct> userProducts = this._userProductService.GetUserProductsByUserId(userId);

                List<UserProductViewModel> userProductViewModels = userProducts.Select(c => new UserProductViewModel
                {
                    UserProductId = c.UserProductId,
                    UserId = c.UserId,
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    ExpirationDate = c.ExpirationDate,
                    ProductName = c.Product.Name,

                }).ToList();

                return Ok(userProductViewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userProductId}")]
        public IActionResult GetUserProductByID([FromRoute] int userProductId)
        {
            try
            {
                UserProduct? userProduct = this._userProductService.GetUserProductByID(userProductId);

                if (userProduct is null)
                {
                    return NotFound();
                }

                UserProductViewModel userProductViewModel = new UserProductViewModel
                {
                    UserProductId = userProduct.UserProductId,
                    UserId = userProduct.UserId,
                    ProductId = userProduct.ProductId,
                    Quantity = userProduct.Quantity,
                    ExpirationDate = userProduct.ExpirationDate,
                    ProductName = userProduct.Product.Name,
                };

                return Ok(userProductViewModel);
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
        public IActionResult AddUserProduct([FromBody] UserProductCreateModel userProductCreateModel)
        {
            try
            {
                UserProduct userProduct = new UserProduct
                {
                    UserId = userProductCreateModel.UserId,
                    ProductId = userProductCreateModel.ProductId,
                    Quantity = userProductCreateModel.Quantity,
                    ExpirationDate = userProductCreateModel.ExpirationDate,
                };

                this._userProductService.AddUserProduct(userProduct);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{userProductId}")]
        public IActionResult DeleteUserProduct([FromRoute] int userProductId)
        {
            try
            {
                this._userProductService.DeleteUserProduct(userProductId);

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

        [HttpPut("{userProductId}")]
        public IActionResult UpdateUserProduct(
            [FromRoute]
            int userProductId,
            [FromBody]
            UserProductCreateModel userProductCreateModel)
        {
            try
            {
                UserProduct userProduct = new UserProduct
                {
                    UserProductId = userProductId,
                    ProductId = userProductCreateModel.ProductId,
                    UserId = userProductCreateModel.UserId,
                    ExpirationDate = userProductCreateModel.ExpirationDate,
                    Quantity = userProductCreateModel.Quantity,
                };

                this._userProductService.UpdateUserProduct(userProduct);

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
