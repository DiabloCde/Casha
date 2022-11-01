using System.ComponentModel.DataAnnotations;

namespace CashaWeb.ViewModels
{
    public class PostCreateModel
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public DateTime? PostedDate { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? UserId { get; set; }

    }
}
