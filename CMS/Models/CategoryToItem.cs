using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class CategoryToItem
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int ItemId { get; set; }

        // Navigation Property
        public Category Category { get; set; }
        public Item Item { get; set; }
    }
}
