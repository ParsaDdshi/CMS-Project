using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class UserFavouriteItem
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ItemId { get; set; }

        //Navigation Properties
        public User User { get; set; }
        public Item  Item{ get; set; }
    }
}
