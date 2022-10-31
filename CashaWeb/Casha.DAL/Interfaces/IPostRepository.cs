using Casha.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.DAL.Interfaces
{
    public interface IPostRepository
    {
        List<Post> GetAllPosts();

        List<Post> GetPostsFiltered(Expression<Func<Post, bool>> filter);

        Post? GetPostByID(int postId);

        void CreatePost(Post post);

        void DeletePost(int postId);

        void UpdatePost(Post post);
    }
}
