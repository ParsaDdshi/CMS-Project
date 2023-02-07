using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class LoginViewModel
    {
        [MaxLength(200)]
        [Required]
        public string UserNameOrEmail { get; set; }

        [Required]
        [MaxLength(200)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
