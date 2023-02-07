using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class RegisterViewModel
    {
        [MaxLength(200)]
        [Required]
        public string UserName { get; set; }

        [Required]
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(200)]
        public string Password { get; set; }

        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
