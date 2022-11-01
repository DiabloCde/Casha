using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Casha.BLL.Interfaces;
using Casha.BLL.Services;
using Casha.Core.DbModels;
using CashaWeb.ViewModels;
using System.Linq.Expressions;

namespace CashaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        private readonly ILogger<PostController> _logger;

        public PostController(IPostService postService, ILogger<PostController> logger)
        {
            _postService = postService;
            _logger = logger;
        }

        [HttpGet("{postId = int}")]
        public IActionResult GetPost([FromRoute] int postId)
        {
            try
            {
                Post? post = _postService.GetPostById(postId);

                if (post == null)
                {
                    return NotFound($"No posts with index{postId}");
                }

                return Ok(post);
            }
            catch(ArgumentNullException e)
            {
                _logger.LogError(e.Message);
                return ValidationProblem(e.Message);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return ValidationProblem(e.Message);
            }
        }
    }
}
