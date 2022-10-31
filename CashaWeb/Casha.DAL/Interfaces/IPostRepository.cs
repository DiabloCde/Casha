using Casha.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Casha.DAL.Interfaces
{
    internal interface IPostRepository
    {
        List<Post> GetPosts(Expression<Func<Post, bool>> filter);

        Post? GetPostByID(string postId);

        void CreatePost(Post post);

        void DeletePost(string postId);

        void UpdatePost(Post post);
    }
}
