using CMS.Models;

namespace CMS.Services.Interfaces
{
    public interface IItemService
    {
        List<Item> GetItems(int count = 9);
        List<Item> GetFavouriteItems(int count = 6);
        List<Category> GetCategories();
    }
}
