using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        // Navigation Property
        public List<CategoryToItem> CategoriesToItems { get; set; }
    }
}
