using Casha.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.BLL.Interfaces
{
    internal interface IPostService
    {
        Post? GEtPostById(int postId);

        List<Post> GetAllPosts();

        List<Post> GetPostsFiltered(string userId = "");

        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeltePost(int psotId);

        /*void UpdateUser(User user);

        void DeleteUser(string userId);

        User? GetUserDetails(string userId);

        List<User> GetUsers(bool isAllUsers = true, bool isCertifiedUsers = false, string search = "");
        */
    }
}
