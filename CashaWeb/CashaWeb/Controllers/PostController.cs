using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Casha.BLL.Interfaces;
using Casha.BLL.Services;
using Casha.Core.DbModels;
using CashaWeb.ViewModels;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace CashaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        private readonly ILogger<PostController> _logger;
        private readonly IUserService _userService;

        public PostController(IPostService postService, ILogger<PostController> logger, IUserService userService)
        {
            _postService = postService;
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("{postId=int}")]
        public IActionResult GetPost([FromRoute] int postId)
        {
            try
            {
                Post? post = _postService.GetPostById(postId);

                if (post == null)
                {
                    return NotFound($"No posts with index {postId}");
                }

                return Ok(post);
            }
            catch (ArgumentNullException e)
            {
                _logger.LogError(e.Message);
                return ValidationProblem(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return ValidationProblem(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            try
            {
                var posts = _postService.GetAllPosts();
                var postViewModels = posts.Select(p => getPostViewModel(p)).ToList();
                return Ok(postViewModels);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        private PostViewModel? getPostViewModel(Post post)
        {
            try
            {
                var user = _userService.GetUserDetails(post.UserId);
                if (user != null)
                {
                    return new PostViewModel
                    {
                        PostId = post.PostId,
                        Title = post.Title,
                        PostedDate = post.PostedDate,
                        Description = post.Description,
                        UserId = post.UserId,
                        DisplayName = user.DisplayName,
                        ProfilePictureUrl = user.ProfilePictureUrl
                    };
                }
                else
                {
                    return new PostViewModel
                    { 
                        PostId = post.PostId,
                        Title = post.Title,
                        PostedDate = post.PostedDate,
                        Description = post.Description,
                        UserId = post.UserId,
                    };
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return null;
            
        }

    }
}
