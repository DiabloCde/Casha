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
            try
            {
                _postRepository.CreatePost(post);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public void DeltePost(int postId)
        {
            if(postId < 0)
            {
                throw new ArgumentNullException("Post id must be greater than 0");
            }

            try
            {
                _postRepository.DeletePost(postId);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public List<Post> GetAllPosts()
        {
            List<Post> posts = new List<Post>();  
            try
            {
                posts = _postRepository.GetAllPosts();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return posts;
        }

        public Post? GetPostById(int postId)
        {
            if (postId < 0)
            {
                throw new ArgumentNullException("Post id must be greater than 0");
            }

            try
            {
               Post? post = _postRepository.GetPostByID(postId);
                return post;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }

            return null;
        }

        public List<Post> GetPostsFiltered(string userId = "")
        {
            List<Post> posts = new List<Post>();
            try
            {
                posts = _postRepository.GetPostsFiltered(p=>p.UserId == userId);
                return posts;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }

            return posts;
        }

        public void UpdatePost(Post post)
        {
            try
            {
                _postRepository.UpdatePost(post);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}
