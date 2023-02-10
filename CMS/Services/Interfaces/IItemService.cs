using CMS.Models;

namespace CMS.Services.Interfaces
{
    public interface IItemService
    {
        List<Item> GetItems(int count = 9);
        List<Item> GetFavouriteItems(int count = 6);
        List<Category> GetCategories();
        Item GetItemById(int? id);
        List<Item> GetCategoryItems(int categoryId);
        List<Category> GetItemCategories(int itemId);
        void Save();
        List<Item> Search(string search);
    }
}
