using Casha.Core.DbModels;
using Casha.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.DAL.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationContext _context;

        public PostRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void DeletePost(int postId)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == postId);

            if(post is not null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }

        public Post? GetPostByID(int postId)
        {
            return _context.Posts
                .Include(p=>p.User)
                .Include(p=>p.Comments)
                .FirstOrDefault(p => p.PostId == postId);
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
