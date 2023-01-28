using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public int Views { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        // Navigation Property
        public List<CategoryToItem> CategoriesToItems { get; set; }
    }
}
