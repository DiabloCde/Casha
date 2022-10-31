using Casha.Core.DbModels;
using Casha.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.DAL.Repositories
{
    internal class PostRepository : IPostRepository
    {
        private readonly ApplicationContext _context;

        public PostRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(string postId)
        {
            throw new NotImplementedException();
        }

        public Post? GetPostByID(string postId)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPosts(Expression<Func<Post, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
