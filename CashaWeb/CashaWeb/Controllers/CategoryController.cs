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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                List<Category> categories = this._categoryService.GetAllCategories();

                List<CategoryViewModel> categoryViewModels = categories.Select(c => new CategoryViewModel
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    CategoryType = c.CategoryType
                }).ToList();
                
                return Ok(categoryViewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("type")]
        public IActionResult GetCategoriesByType([FromQuery] CategoryType categoryType)
        {
            try
            {
                List<Category> categories = this._categoryService.GetCategoriesByType(categoryType);

                List<CategoryViewModel> categoryViewModels = categories.Select(c => new CategoryViewModel
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    CategoryType = c.CategoryType
                }).ToList();

                return Ok(categoryViewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{categoryId}")]
        public IActionResult GetCategoryByID([FromRoute] int categoryId)
        {
            try
            {
                Category? category = this._categoryService.GetCategoryByID(categoryId);

                if (category is null)
                {
                    return NotFound();
                }

                CategoryViewModel categoryViewModel = new CategoryViewModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategoryType = category.CategoryType
                };

                return Ok(categoryViewModel);
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
        public IActionResult AddCategory([FromBody] CategoryCreateModel categoryCreateModel)
        {
            try
            {
                Category category = new Category
                {
                    CategoryName = categoryCreateModel.CategoryName,
                    CategoryType = categoryCreateModel.CategoryType
                };

                this._categoryService.AddCategory(category);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory([FromRoute] int categoryId)
        {
            try
            {
                this._categoryService.DeleteCategory(categoryId);

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

        [HttpPut("{categoryId}")]
        public IActionResult UpdateCategory(
            [FromRoute] 
            int categoryId,
            [FromBody] 
            CategoryCreateModel categoryCreateModel)
        {
            try
            {
                Category category = new Category
                {
                    CategoryId = categoryId,
                    CategoryName = categoryCreateModel.CategoryName,
                    CategoryType = categoryCreateModel.CategoryType
                };

                this._categoryService.UpdateCategory(category);

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
