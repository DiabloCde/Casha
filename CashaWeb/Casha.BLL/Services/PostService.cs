using Casha.BLL.Interfaces;
using Casha.Core.DbModels;
using Casha.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Services
{
    internal class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ILogger<PostService> _logger;

        public PostService(IPostRepository postRepository, ILogger<PostService> logger)
        {
            _postRepository = postRepository;
            _logger = logger;
        }

        public void CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public void DeltePost(int psotId)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Post? GEtPostById(int postId)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPostsFiltered(string userId = "")
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
