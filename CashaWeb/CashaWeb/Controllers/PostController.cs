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

                var postView = getPostViewModel(post);
                return Ok(postView);
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
                        PostImageUrl = post.PostImageUrl,
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
                        PostImageUrl = post.PostImageUrl,
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

        [HttpPost]
        public IActionResult CreatePost(PostCreateModel postView)
        {
            try
            {
                var post = new Post
                {
                    Title = postView.Title == null ? "No title" : postView.Title,
                    PostedDate = postView.PostedDate == null ? DateTime.Today : postView.PostedDate.Value,
                    Description = postView.Description == null ? "No Description" : postView.Description,
                    PostImageUrl = postView.PostImageUrl,
                    UserId = postView.UserId == null ? "No User in post" : postView.UserId
                };

                _postService.CreatePost(post);
                PostViewModel? postViewModel = getPostViewModel(post);
                return Ok(postViewModel);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpDelete("{postId=int}")]
        public IActionResult DeletePost([FromRoute] int postId)
        {
            try
            {
                _postService.DeltePost(postId);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{postId=int}")]
        public IActionResult UpdatePost([FromRoute] int postId, [FromBody] PostCreateModel postUpdate)
        {
            try
            {
                var post = new Post
                {
                    PostId = postId,
                    Title = postUpdate.Title == null ? "No title" : postUpdate.Title,
                    PostedDate = postUpdate.PostedDate == null ? DateTime.Today : postUpdate.PostedDate.Value,
                    Description = postUpdate.Description == null ? "No Description" : postUpdate.Description,
                    PostImageUrl = postUpdate.PostImageUrl,
                    UserId = postUpdate.UserId == null ? "" : postUpdate.UserId
                };

                _postService.UpdatePost(post);
                var postViewModel = getPostViewModel(post);
                return Ok(postViewModel);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("UserPosts/{userId=string}")]

        public IActionResult GetPostsByUserId([FromRoute] string userId)
        {
            try
            {
                var posts = _postService.GetPostsFiltered(userId);
                List<PostViewModel> postViewModels = new List<PostViewModel>();

                foreach (var post in posts)
                {
                    var postView = getPostViewModel(post);

                    if (postView is null)
                    {
                        continue;
                    }

                    postViewModels.Add(postView);
                }

                return Ok(postViewModels);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

    }
}
