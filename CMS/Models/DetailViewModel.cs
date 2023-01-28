namespace CMS.Models;

public class DetailViewModel
{
    public int ItemId { get; set; }
    
    public string Title { get; set; }

    public string Text { get; set; }

    public int Views { get; set; }

    public DateTime CreateDate { get; set; }
    
    public List<Category> CategoriesName { get; set; }
}