using System.ComponentModel.DataAnnotations;

namespace CashaWeb.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
