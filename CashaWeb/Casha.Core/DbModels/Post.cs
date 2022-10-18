using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.Core.DbModels
{
    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public DateTime PostedDate { get; set; }
    
        public string Description { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
