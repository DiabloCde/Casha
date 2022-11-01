using System.ComponentModel.DataAnnotations;

namespace CashaWeb.ViewModels
{
    public class PostCreateModel
    {
        public string? Title { get; set; }

        public DateTime? PostedDate { get; set; }

        public string? Description { get; set; }

        public string? UserId { get; set; }
    }
}
