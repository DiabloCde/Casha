using Casha.Core.DbModels;

namespace CashaWeb.ViewModels
{
    public class PostViewModel
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public DateTime PostedDate { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public string DisplayName { get; set; }

        public string ProfilePictureUrl { get; set; }
    }
}
