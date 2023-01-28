namespace CMS.Models
{
    public class CategoryToItem
    {
        public int CategoryId { get; set; }
        public int ItemId { get; set; }

        // Navigation Property
        public Category Category { get; set; }
        public Item Item { get; set; }
    }
}
