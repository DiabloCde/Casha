using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.Core.DbModels
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public string Bio { get; set; }

        public string ProfilePictureUrl { get; set; }

        public bool IsCertified { get; set; }
        
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }

        public List<Post> Posts { get; set; }

        public List<Recipe> Recipes { get; set; }

        public List<Comment> Comments { get; set; }

        public List<UserProduct> UserProducts { get; set; }

       
    }
}
