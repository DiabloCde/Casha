using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casha.Core.DbModels
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string CommentBody { get; set; }

        public DateTime CreatedDate { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

        public string UserId { get; set; }  

        public User User { get; set; }
    }
}
