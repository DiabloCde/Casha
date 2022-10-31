using Casha.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Interfaces
{
    public interface IPostService
    {
        Post? GetPostById(int postId);

        List<Post> GetAllPosts();

        List<Post> GetPostsFiltered(string userId = "");

        void CreatePost(Post post);

        void UpdatePost(Post post);

        void DeltePost(int psotId);
    }
}
