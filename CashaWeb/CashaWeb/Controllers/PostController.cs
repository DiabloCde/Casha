using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Casha.BLL.Interfaces;
using Casha.BLL.Services;

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
    }
}
