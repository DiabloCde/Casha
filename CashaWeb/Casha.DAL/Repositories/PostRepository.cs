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

        public List<Post> GetAllPosts()
        {
            return _context.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                .ToList();
        }

        public List<Post> GetPostsFiltered(Expression<Func<Post, bool>> filter)
        {
            return _context.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                .Where(filter).ToList();
        }

        public void UpdatePost(Post post)
        {
            Post? oldPost = _context.Posts.FirstOrDefault(p => p.PostId == post.PostId);

            if(oldPost is not null)
            {
                oldPost.Description = post.Description;
                oldPost.PostedDate = post.PostedDate;
                oldPost.Title = post.Title;
                oldPost.UserId = post.UserId;

                _context.Posts.Update(oldPost);
                _context.SaveChanges();
            }
        }
    }
}
