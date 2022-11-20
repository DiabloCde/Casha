using Casha.BLL.Interfaces;
using Casha.Core.DbModels;
using Casha.Core.Dtos;
using CashaWeb.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        private readonly ILogger<RecipeController> _logger;

        public RecipeController(IRecipeService recipeService, ILogger<RecipeController> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetRecipes([FromBody] RecipeFilterDto recipeFilter)
        {
            try
            {
                List<Recipe> recipes = this._recipeService.GetRecipes(recipeFilter);

                List<RecipeViewModel> recipeViewModels = recipes.Select(recipe => new RecipeViewModel
                {
                    RecipeId = recipe.RecipeId,
                    Name = recipe.Name,
                    RecipeImageUrl = recipe.RecipeImageUrl,
                    Difficulty = recipe.Difficulty,
                    Instruction = recipe.Instruction,
                    UserId = recipe.UserId,
                    UserName = recipe.User.DisplayName,
                    RecipeCategories = recipe.RecipeCategories.Select(r => new RecipeCategoryViewModel
                    {
                        CategoryId = r.CategoryId,
                        CategoryName = r.Category.CategoryName,
                        CategoryType = r.Category.CategoryType,
                        RecipeId = r.RecipeId
                    }).ToList(),
                    RecipeProducts = recipe.RecipeProducts.Select(r => new RecipeProductViewModel
                    {
                        RecipeId = r.RecipeId,
                        ProductId = r.ProductId,
                        ProductName = r.Product.Name,
                        Quantity = r.Quantity,
                        Unit = r.Unit
                    }).ToList()
                }).ToList();

                return Ok(recipeViewModels);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{recipeId}")]
        public IActionResult GetRecipeByID(int recipeId)
        {
            try
            {
                Recipe? recipe = this._recipeService.GetRecipeByID(recipeId);

                if (recipe is null)
                {
                    return NotFound();
                }

                RecipeViewModel recipeViewModel = new RecipeViewModel
                {
                    RecipeId = recipe.RecipeId,
                    Name = recipe.Name,
                    RecipeImageUrl = recipe.RecipeImageUrl,
                    Difficulty = recipe.Difficulty,
                    Instruction = recipe.Instruction,
                    UserId = recipe.UserId,
                    UserName = recipe.User.DisplayName,
                    RecipeCategories = recipe.RecipeCategories.Select(r => new RecipeCategoryViewModel
                    {
                        CategoryId = r.CategoryId,
                        CategoryName = r.Category.CategoryName,
                        CategoryType = r.Category.CategoryType,
                        RecipeId = r.RecipeId
                    }).ToList(),
                    RecipeProducts = recipe.RecipeProducts.Select(r => new RecipeProductViewModel
                    {
                        RecipeId = r.RecipeId,
                        ProductId = r.ProductId,
                        ProductName = r.Product.Name,
                        Quantity = r.Quantity,
                        Unit = r.Unit
                    }).ToList()
                };

                return Ok(recipeViewModel);
            }
            catch (ArgumentNullException ex)
            {
                this._logger.LogError(ex.Message);

                return ValidationProblem(ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddRecipe([FromBody] RecipeCreateModel recipeCreateModel)
        {
            try
            {
                Recipe recipe = new Recipe
                {
                    Name = recipeCreateModel.Name,
                    Instruction = recipeCreateModel.Instruction,
                    RecipeImageUrl = recipeCreateModel.RecipeImageUrl,
                    Difficulty = recipeCreateModel.Difficulty,
                    UserId = recipeCreateModel.UserId,
                    RecipeProducts = recipeCreateModel.RecipeProducts.Select(r => new RecipeProduct
                    {
                        ProductId = r.ProductId,
                        Unit = r.Unit,
                        Quantity = r.Quantity,
                    }).ToList(),
                    RecipeCategories = recipeCreateModel.RecipeCategories.Select(c => new RecipeCategory
                    {
                        CategoryId = c,
                    }).ToList()
                };

                this._recipeService.AddRecipe(recipe);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{recipeId}")]
        public IActionResult DeleteRecipe(int recipeId)
        {
            try
            {
                this._recipeService.DeleteRecipe(recipeId);

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                this._logger.LogError(ex.Message);

                return ValidationProblem(ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateRecipe(
            [FromRoute]
            int recipeId,
            [FromBody] 
            RecipeUpdateModel recipeUpdateModel)
        {
            try
            {
                Recipe recipe = new Recipe
                {
                    RecipeId = recipeId,
                    Name = recipeUpdateModel.Name,
                    Instruction = recipeUpdateModel.Instruction,
                    RecipeImageUrl = recipeUpdateModel.RecipeImageUrl,
                    Difficulty = recipeUpdateModel.Difficulty,
                    UserId = recipeUpdateModel.UserId,
                    RecipeProducts = recipeUpdateModel.RecipeProducts.Select(r => new RecipeProduct
                    {
                        RecipeId = r.RecipeId,
                        ProductId = r.ProductId,
                        Unit = r.Unit,
                        Quantity = r.Quantity,
                    }).ToList(),
                    RecipeCategories = recipeUpdateModel.RecipeCategories.Select(c => new RecipeCategory
                    {
                        RecipeId = c.RecipeId,
                        CategoryId = c.CategoryId,
                    }).ToList()
                };

                this._recipeService.UpdateRecipe(recipe);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("product/{recipeId}")]
        public IActionResult AddProductToRecipe(
            [FromRoute] 
            int recipeId, 
            [FromBody] 
            RecipeProductCreateModel recipeProductCreateModel)
        {
            try
            {
                RecipeProduct recipeProduct = new RecipeProduct
                {
                    RecipeId = recipeId,
                    ProductId = recipeProductCreateModel.ProductId,
                    Quantity = recipeProductCreateModel.Quantity,
                    Unit = recipeProductCreateModel.Unit
                };

                this._recipeService.AddProductToRecipe(recipeProduct);

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                this._logger.LogError(ex.Message);

                return ValidationProblem(ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("product/{recipeId}/{producrId}")]
        public IActionResult RemoveProductFromRecipe(
            [FromRoute] 
            int productId, 
            [FromRoute] 
            int recipeId)
        {
            try
            {                
                this._recipeService.RemoveProductFromRecipe(productId, recipeId);

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                this._logger.LogError(ex.Message);

                return ValidationProblem(ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("product/{recipeId}")]
        public IActionResult UpdateProductInRecipe(
            [FromRoute]
            int recipeId,
            [FromBody]
            RecipeProductCreateModel recipeProductCreateModel)
        {
            try
            {
                RecipeProduct recipeProduct = new RecipeProduct
                {
                    RecipeId = recipeId,
                    ProductId = recipeProductCreateModel.ProductId,
                    Quantity = recipeProductCreateModel.Quantity,
                    Unit = recipeProductCreateModel.Unit
                };

                this._recipeService.UpdateProductInRecipe(recipeProduct);

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                this._logger.LogError(ex.Message);

                return ValidationProblem(ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("category/{recipeId}")]
        public IActionResult AddCategoryToRecipe(
            [FromRoute]
            int recipeId,
            [FromBody]
            RecipeCategoryViewModel recipeCategoryViewModel)
        {
            try
            {
                RecipeCategory recipeCategory = new RecipeCategory
                {
                    RecipeId = recipeId,
                    CategoryId = recipeCategoryViewModel.CategoryId
                };

                this._recipeService.AddCategoryToRecipe(recipeCategory);

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                this._logger.LogError(ex.Message);

                return ValidationProblem(ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("category/{recipeId}/{categoryId}")]
        public IActionResult RemoveCategoryFromRecipe(
            [FromRoute] 
            int categoryId, 
            [FromRoute]
            int recipeId)
        {
            try
            {
                this._recipeService.RemoveCategoryFromRecipe(categoryId, recipeId);

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                this._logger.LogError(ex.Message);

                return ValidationProblem(ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
