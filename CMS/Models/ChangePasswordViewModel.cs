using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class ChangePasswordViewModel
    {

        [Required]
        [MaxLength(200)]
        public string OldPassword { get; set; }

        [Required]
        [MaxLength(200)]
        public string NewPassword { get; set; }

        [Compare("NewPassword")]
        public string ReNewPassword { get; set; }
    }
}
