using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(200)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(200)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RegisterDate { get; set; }

        public bool IsAdmin { get; set; }
    }
}
